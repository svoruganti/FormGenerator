class FormGeneratorComponent extends React.Component {
    constructor(props) {
        super(props);
        this.branchingControls = this.props.branching === undefined ? [] : JSON.parse(this.props.branching);
        this.hasBranchingControls = this.branchingControls.length === 0;
    }

    getInitialState() {
        return {
            value: "",
            isVisible: this.hasBranchingControls,
            validationState: null,
            validationMessages: new Map()
        }
    }

    getIsVisible(formData) {
        if (this.hasBranchingControls)
            return true;
        let i = false;
        this.branchingControls.forEach((item) => {
            if (formData[item.ParentCode] === item.BranchingValue) {
                i = true;
                return;
            }
        });
        return i;
    }

    getIsVisibleClassName() {
        return this.state.isVisible ? "show" : "hidden";
    }

    validate() {
        if (!this.state.isVisible) {
            this.setState({ validationState: null });
            return;
        }

        let messages = new Map();
        console.log(this.state);
        if (this.state.isVisible && (this.state.value != undefined || this.state.value.trim().length === 0)) {
            this.setState({ validationState: "error" });
            messages.set(this.props.code, "is required");
        } else
            this.setState({ validationState: null });
        this.setState({validationMessages : messages});
        //store.dispatch(returnValidationAction(messages));
    }

    handleChange(e) {
        this.setState({ value: e.target.value });
        this.validate();
        store.dispatch(returnBranchingAction(e));
    }

    setValidationMessages(messages) {
        this.setState({validationMessages : messags})
    }
    
    handleControlledComponentChange(e) {
        this.setState({ value: e.target.value });
    }

    handleBlur(e) {
        this.setState({value: e.target.value})
        this.validate();
        store.dispatch(returnBranchingAction(e));
    }

    componentDidMount() {
        store.subscribe(() => {
            let fd = store.getState().formData;
            this.setState({isVisible: this.getIsVisible(fd), value:fd[this.props.code]});
        });
    }

}