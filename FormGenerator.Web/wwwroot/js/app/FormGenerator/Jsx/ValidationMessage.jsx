class ValidationMessage extends React.Component {
    constructor(props) {
        super(props);
    }

    render() {
        if (this.props.messages.size > 0) {
            let vm = this.props.messages;
            let m = vm.forEach(function(value, key, map) {
                return (<li>is required</li>);
            }, this);
            console.log(m);
            return (
                <ul>
                    <li>{m}</li>
                </ul>
            );
        } else
            return null;
    }
}