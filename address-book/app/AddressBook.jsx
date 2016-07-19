(function () {

    var AddressBook = React.createClass({
        getInitialState: function () {
            return {
                contacts: []
            }
        },
        componentDidMount: function () {
            this.serverRequest = $.get('/api/contacts', function (result) {
                this.setState({
                    contacts: result
                });
            }.bind(this));
        },
        handleContactCreated: function (contact) {

            // save the contact
            $.ajax({
                url: "/api/contacts",
                type: "POST",
                dataType: "json",
                contentType: "application/json",
                data: JSON.stringify(this.state),
                success: function () {
                    console.log('saved');
                }.bind(this)
            });

            this.setState({
                contacts: this.state.contacts.concat([contact])
            });
        },
        render: function () {
            return (
 <div className="row">
    <div className="col-md-4">
        <CreateContact onCreated={this.handleContactCreated} />
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
            e.preventDefault();
            this.props.onCreated(this.state);
            this.setState(this.getInitialState());
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
            return (
              <ol>
                {this.props.contacts.map(function (result, i) {
                    return <li key={i}>{result.name}</li>;
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