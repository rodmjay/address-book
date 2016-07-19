(function () {

    var AddressBook = React.createClass({
        getInitialState: function () {
            return {
                contacts: [],
                editContact: null
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
                    //console.log('deleted');
                }.bind(this)
            });

            this.setState({
                contacts: this.state.contacts.filter((_, i) => i !== id)
            });

        },
        edit: function(e) {
            var id = e.target.getAttribute('data-key');
            this.setState({
                editContact: this.state.contacts.filter((_, i) => i === id)
            });
        },
        update: function(id, contact) {
            $.ajax({
                url: "/api/contacts/"+id,
                type: "POST",
                dataType: "json",
                contentType: "application/json",
                data: JSON.stringify(contact),
                success: function () {
                    //console.log('saved');
                }.bind(this)
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
                    //console.log('saved');
                }.bind(this)
            });

            this.setState({
                contacts: this.state.contacts.concat([contact])
            });
        },
        render: function () {
            return (
 <div className="row">
    <div className="col-md-3">
        <CreateContact onSave={this.save} />
    </div>
    <div className="col-md-9 well">
        <table className="table">
            <thead>
                <tr>
                    <th>Name</th>
                    <th>Phone Number</th>
                </tr>
            </thead>
                  <tbody>
                      {this.state.contacts.map(function (result, i) {
                          return (
                              <Contact key={i}
                                       id={i} 
                                       contact={result} 
                                       onUpdate={this.update}
                                       onDestroy={this.destroy}/>);
                      }.bind(this))}
                  </tbody>

        </table>
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
            this.props.onSave(this.state);
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

    var Contact = React.createClass({
        handleUpdateButtonClick:function(e) {
            this.props.onUpdate(this.props.id, this.state);
        },
        handleDeleteButtonClick: function (e) {
            this.props.onDestroy(this.props.id);
        },
        handlePhoneNumberChange: function (e) {
            this.setState({ phoneNumber: e.target.value });
        },
        handleNameChange: function (e) {
            this.setState({ name: e.target.value });
        },
        getInitialState:function() {
            return{
                name: this.props.contact.name,
                phoneNumber: this.props.contact.phoneNumber
            }
        },
        render: function () {
            return (
              <tr>
                <th><input type="text" onChange={this.handleNameChange} className="form-control" value={this.state.name} /></th>
                <td><input type="text" onChange={this.handlePhoneNumberChange} className="form-control" value={this.state.phoneNumber} /></td>
                <td>
                    <button className="btn" onClick={this.handleDeleteButtonClick}>Delete</button>
                    <button className="btn" onClick={this.handleUpdateButtonClick}>Update</button>
                </td>
              </tr>
            );
        }
    });

    ReactDOM.render(
			<AddressBook />,
			document.getElementById('addressbook')
		);
})();