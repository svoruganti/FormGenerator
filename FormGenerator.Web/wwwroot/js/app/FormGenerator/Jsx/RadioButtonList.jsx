class RadioButtonList extends FormGeneratorComponent {
    constructor (props) {
        super(props);
        this.state = this.getInitialState();
    }
    render() {
        let json = JSON.parse(this.props.children);
        let radioButtons = json.map(function(item, index) {
                return (
                    <ReactBootstrap.Radio key={index} name={this.props.code} id={this.props.code +
                        "_" +
                        item.Id} value={item.Id} onClick={this.handleRadioButtonClick.bind(this)} inline checked={this.state.value == item.Id}>
                        {item.Description}
                    </ReactBootstrap.Radio>);
            },
            this);
        return (
            <ReactBootstrap.FormGroup className={this.getIsVisibleClassName(this.state)}>
                <ReactBootstrap.Col sm={this.props.cols}>
                    <ReactBootstrap.ControlLabel htmlFor={this.props.code}>{this.props.label}</ReactBootstrap.ControlLabel>
                    {radioButtons}
                </ReactBootstrap.Col>
            </ReactBootstrap.FormGroup>
        );
    }

    handleRadioButtonClick(e) {
        store.dispatch({type:BRANCHING, payload:{controlId:e.target.name, value:e.target.value}});
    }
}