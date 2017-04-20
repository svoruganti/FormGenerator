class CheckboxList extends React.Component{
    constructor(props){
        super(props);
        this.state = {value : new Set()}
    }
    render() {
        let json = this.props.children === undefined ? [] : JSON.parse(this.props.children);
        let boxes = json.map((item, index) => {
            return (<ReactBootstrap.Checkbox value={item.Id} onClick={this.handleClick.bind(this)} inline>{item.Description}</ReactBootstrap.Checkbox>
        });
        return (
            <ReactBootstrap.FormGroup controlId={this.props.code}>
                <ReactBootstrap.ControlLabel>{this.props.label}</ReactBootstrap.ControlLabel>
                {boxes}
            </ReactBootstrap.FormGroup>
        );
    }
    handleClick(e){
        if (this.state.value.has(e.target.value)
            this.state.value.delete(e.target.value);
        else
            this.state.value.add(e.target.value);
        store.dispatch({type: BRANCHING, payload:{controlId:this.props.code, value: this.state.value}};
    }
}
