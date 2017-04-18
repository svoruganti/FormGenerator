class ValidationMessage extends React.Component {
    constructor(props) {
        super(props);
    }

    render() {
        if (this.props.messages.size > 0) {
            let m = $.each(this.props.messages, function(key, value) {
                return (<li>{value}</li>);
            }, this);
            
            return (
                <ul>
                    {m}
                </ul>
            );
        } else
            return null;
    }
}
