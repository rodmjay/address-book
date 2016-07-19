(function () {

    var AddressBook = React.createClass({
        getInitialState: function () {
            return {
                contacts: []
            }
        },
        componentDidMount: function () {
            $.get('/api/contacts', function (result) {
                this.setState({
                    contacts: result
                });
            }.bind(this));
        },
        destroy: function (e) {

            var id = parseInt(e.target.getAttribute('data-key'));

            $.ajax({
                url: "/api/contacts/" + id,
                type: "DELETE",
                dataType: "json",
                success: function () {
                    console.log('deleted');
                }.bind(this)
            });

            this.setState({
                contacts: this.state.contacts.filter((_, i) => i !== id)
            });

        },
        save: function (contact) {
            $.ajax({
                url: "/api/contacts",
                type: "POST",
                dataType: "json",
                contentType: "application/json",
                data: JSON.stringify(contact),
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
        <CreateContact save={this.save} />
    </div>
    <div className="col-md-8">
        <ContactList contacts={this.state.contacts} onDestroy={this.destroy} />
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
        handleSubmit: function (e) {
            e.preventDefault();
            this.props.save(this.state);
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
<form onSubmit={this.handleSubmit}>
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
      <button 
              type="submit" 
              className="btn btn-default">Create Contact</button>
</form>);
        }
    });

    var ContactList = React.createClass({
        render: function () {
            return (
              <table className="table">
                  <tbody>
                      
                      {this.props.contacts.map(function (result, i) {
                          
                          return (<tr key={i}>
                              <th>{result.name}</th>
                              <td>{result.phoneNumber}</td>
                              <td>
                                  <button data-key={i} className="btn" onClick={this.props.onDestroy}>Delete</button>
                              </td>
                          </tr>);
                      }.bind(this))}
                  </tbody>
               
              </table>
            );
        }
    });

    ReactDOM.render(
			<AddressBook />,
			document.getElementById('addressbook')
		);
})();