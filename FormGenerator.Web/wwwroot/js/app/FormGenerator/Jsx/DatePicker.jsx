class DatePicker extends FormGeneratorComponent {
    constructor(props) {
        super(props);
        this.state = this.getInitialState();
    }

    render() {
        return (
            <ReactBootstrap.FormGroup controlId={this.props.code} className={this.getIsVisibleClassName()} validationState={this.state.validationState}>
                <ReactBootstrap.Col sm={this.props.cols}>
                    <ReactBootstrap.ControlLabel>{this.props.label}</ReactBootstrap.ControlLabel>
                    <ReactBootstrap.FormControl type="text" name={this.props.code} onChange={this.handleControlledComponentChange.bind(this)} onBlur={this.handleBlur.bind(this)} value={this.state.value}/>
                </ReactBootstrap.Col>
            </ReactBootstrap.FormGroup>
        );
    }
}