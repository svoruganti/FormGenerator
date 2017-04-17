class Label extends React.Component{
    constructor(props){
        super(props);
    }
    render(){
        return <label htmlFor={this.props.for}>{this.props.description}</label>;
    }
}