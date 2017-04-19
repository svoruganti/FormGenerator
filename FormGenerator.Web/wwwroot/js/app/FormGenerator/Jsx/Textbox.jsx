class Textbox extends FormGeneratorComponent{
    constructor(props){
        super(props);
        this.state = this.getComponentInitialState();
    }
    render() {
        return (
            <ReactBootstrap.FormGroup controlId={this.props.code} bsSize="small" className={this.getIsVisibleClassName()} validationState={this.state.validationState}>
                <ReactBootstrap.Col sm={this.props.cols}>
                    <ReactBootstrap.ControlLabel>{this.props.label}</ReactBootstrap.ControlLabel>
                    <ReactBootstrap.FormControl type="text" name={this.props.code} value={this.state.value} onChange={this.handleControlledComponentChange.bind(this)} onBlur={this.handleBlur.bind(this)}/>
                    <ValidationMessage messages={this.state.validationMessages}/>
                </ReactBootstrap.Col>
            </ReactBootstrap.FormGroup>
        );
    }
}