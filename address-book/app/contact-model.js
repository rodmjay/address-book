var app = app || {};
(function () {
    'use strict';

    var Utils = app.Utils;

    app.ContactModel = function (key) {
        this.key = key;
        this.contacts = Utils.store(key);
        this.onChanges = [];
    };

    app.ContactModel.prototype.subscribe = function (onChange) {
        this.onChanges.push(onChange);
    };

    app.ContactModel.prototype.inform = function () {
        Utils.store(this.key, this.contacts);
        this.onChanges.forEach(function (cb) { cb(); });
    };

    app.ContactModel.prototype.addContact = function (name, phone) {
        this.contacts = this.contacts.concat({
            id: Utils.uuid(),
            name: name,
            phoneNumber: phone
        });

        this.inform();
    };


    app.ContactModel.prototype.destroy = function (contact) {
        this.contacts = this.contacts.filter(function (candidate) {
            return candidate !== contact;
        });

        this.inform();
    };

    app.ContactModel.prototype.save = function (contactToSave, name, phone) {
        this.contacts = this.contacts.map(function (contact) {
            return contact !== contactToSave ? contact : {
                name: name,
                phoneNumber: phone
            };
        });

        this.inform();
    };

})();
