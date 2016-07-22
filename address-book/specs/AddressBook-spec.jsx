describe("AddressBook", function () {
    var instance;
    var container = document.getElementById('addressbook');

    beforeEach(function () {
        instance = ReactDOM.render(<AddressBook />, container);
        spyOn($, 'ajax').and.callFake(function (req) { });
        instance.setState({
            contacts: []
        });
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
        function () {
            instance.create({
                name: 'test',
                phoneNumber: 'test2'
            });
            instance.update(0,
                   {
                       name: 'updated',
                       phoneNumber: 'updated2'
                   });

            expect(instance.state.contacts[0].name).toEqual('updated');
           
        });

    it('should be able to delete a contact',
       function () {
           instance.create({
               name: 'test',
               phoneNumber: 'test2'
           });

           instance.destroy(0,
                  {
                      name: 'updated',
                      phoneNumber: 'updated2'
                  });
           expect(instance.state.contacts.length).toEqual(0);


       });

});
