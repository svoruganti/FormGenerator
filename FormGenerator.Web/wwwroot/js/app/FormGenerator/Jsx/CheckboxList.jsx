class CheckboxList extends React.Component{
    render() {
        return (
            <ReactBootstrap.FormGroup controlId={this.props.code}>
                <input type="check" id={this.props.id} name={this.props.id}/>
            </ReactBootstrap.FormGroup>
        );
    }
}