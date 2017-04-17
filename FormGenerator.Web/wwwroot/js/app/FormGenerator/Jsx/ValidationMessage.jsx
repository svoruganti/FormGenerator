class ValidationMessage extends React.Component {
    constructor(props) {
        super(props);
    }

    render() {
        if (this.props.messages.size > 0) {
            let vm = this.props.messages;
            let m = Object.values(vm).forEach(function(item) {
                return (<li>{item}</li>);
            }, this);
            console.log(Object.keys(vm));
            return (
                <ul>
                    <li>{m}</li>
                </ul>
            );
        } else
            return null;
    }
}