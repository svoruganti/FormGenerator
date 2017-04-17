class Dropdown extends React.Component {
    constructor(props) {
        super(props);
    }

    render() {
        let json = JSON.parse(this.props.children);
        let optionItems = json.map(function(item) {
                return(
                    <option value={item.Id}>{item.Description}</option>
                );
            },
            this);
        return (
            <ReactBootstrap.FormGroup controlId={this.props.id}>
                <ReactBootstrap.Col sm={this.props.cols}>
                    <ReactBootstrap.ControlLabel>{this.props.label}</ReactBootstrap.ControlLabel>
                    <ReactBootstrap.FormControl componentClass="select" placeholder="select">
                        {optionItems}
                    </ReactBootstrap.FormControl>
                </ReactBootstrap.Col>
            </ReactBootstrap.FormGroup>
        );
    }
}