class SaveButton extends React.Component {
    constructor(props) {
        super(props);
    }

    render() {
        return (
            <ReactBootstrap.FormGroup>
                <ReactBootstrap.Col sm={this.props.cols}>
                    <ReactBootstrap.Button id={this.props.id} name={this.props.id} type="submit" bsStyle="primary">Save</ReactBootstrap.Button>
                </ReactBootstrap.Col>
            </ReactBootstrap.FormGroup>
        );
    }
}