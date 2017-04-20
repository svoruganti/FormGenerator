class FormGeneratorComponent extends React.Component {
    constructor(props) {
        super(props);
        this.branchingControls = this.props.branching === undefined ? [] : JSON.parse(this.props.branching);
        this.hasBranchingControls = this.branchingControls.length === 0;
    }

    getComponentInitialState() {
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
        this.setState({ validationState: null });
        if (!this.state.isVisible) {
            return;
        }

        let messages = new Map();
        if (this.state.isVisible && (this.state.value === undefined || this.state.value.trim().length === 0)) {
            messages.set(this.props.code, "is required");
        }
        
        this.setState({validationMessages : messages});
        if (messages.size > 0){
            this.setState({validationState: "error"});
            store.dispatch(returnValidationAction(false));
        }
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
