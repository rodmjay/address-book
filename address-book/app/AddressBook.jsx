(function () {

    var contactService = (function() {
        return{
            save: function(contact, name, phoneNumber) {
                console.log('contact', contact);
            },
            create: function(name, phoneNumber) {
                console.log('create',
                {
                    name: name,
                    phoneNumber: phoneNumber
                });
            }
        }
    })();

    var AddressBook = React.createClass({
        getInitialState:function() {
            return {
                contacts:[]
            }
        },
        componentDidMount: function () {
            this.serverRequest = $.get('/api/contacts', function (result) {
                this.setState({
                    contacts: result
                });
            }.bind(this));
        },
        render: function () {
            return (
 <div className="row">
    <div className="col-md-4">
        <CreateContact />
    </div>
    <div className="col-md-8">
        <ContactList contacts={this.state.contacts} />
    </div>
</div>);
        }
    });

    var CreateContact = React.createClass({
        getInitialState: function() {
            return {
                name: '',
                phoneNumber: ''
            }
        },
        save: function (e) {
            var self = this;
            e.preventDefault();

            $.ajax({
                url: "/api/contacts",
                type: "POST",
                dataType: "json",
                contentType: "application/json",
                data: JSON.stringify(self.state),
                success: function () {
                    self.setState({
                        name: '',
                        phoneNumber: ''
                    });
                }
            });

        },
        handlePhoneNumberChange: function (e) {
            this.setState({ phoneNumber: e.target.value });
        },
        handleNameChange: function (e) {
            this.setState({ name: e.target.value });
        },
        render: function () {
            return (
<form onSubmit={this.save}>
    <div className="form-group">
    <input placeholder="Name"
           type="text"
           value={this.state.name}
           onChange={this.handleNameChange}
           className="form-control" />
    </div>
    <div className="form-group">
    <input placeholder="Phone"
           type="text"
           value={this.state.phoneNumber}
           onChange={this.handlePhoneNumberChange}
           className="form-control" />
    </div>
      <button type="submit" className="btn btn-default">Create Contact</button>
</form>);
        }
    });

    var ContactList = React.createClass({

        render: function () {
            var results = this.props.contacts;
            return (
              <ol>
                {results.map(function(result) {
                    return <li key={result.name}>{result.name}</li>;
                })}
              </ol>
            );
        }
    });

    ReactDOM.render(
			<AddressBook />,
			document.getElementById('addressbook')
		);
})();