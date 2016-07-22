describe("AddressBook", function () {
    var instance;
    var container = document.getElementById('addressbook');

    beforeEach(function () {
        instance = ReactDOM.render(<AddressBook />, container);
        console.log(instance);

        // crush the old contacts
        for (var i = 0; i < instance.state.contacts.length; i++) {
            instance.destroy(i);
        }
    });

    it("should be able to create a contact", function () {
        var count = instance.state.contacts.length;
        instance.create({
            name: 'test',
            phoneNumber: 'test2'
        });
        expect(instance.state.contacts.length).toEqual(count + 1);
    });

    it('should be able to update a contact',
        function() {
            instance.create({
                name: 'test',
                phoneNumber: 'test2'
            },function() {
                instance.update(0,
                {
                    name: 'updated',
                    phoneNumber: 'updated2'
                },function() {
                });
            });
            expect(instance.state.contacts[0].name).toEqual('updated');

        });

    it('should be able to delete a contact',
       function () {
           instance.create({
               name: 'test',
               phoneNumber: 'test2'
           }, function () {
               instance.destroy(0, function() {
               });
           });
           expect(instance.state.contacts.length).toEqual(0);

       });

});
