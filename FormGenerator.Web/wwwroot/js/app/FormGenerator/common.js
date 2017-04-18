const formState = { formData: new Map(), validationMessages: new Map() };
const store = Redux.createStore(formReducer, formState);

var BRANCHING = "Branching";
var LOAD = "Load";
function formReducer(state = formState, action) {
    let newState;
    switch (action.type) {
        case BRANCHING:
            newState = {
                formData: state.formData
            };
            newState.formData[action.payload.controlId] = action.payload.value;
            return newState;
        case LOAD:
            newState = {
                formData: action.payload
            };
            return newState;
        default:
            console.log("Int form reducer switch default is called");
    }
}

function returnBranchingAction(e) {
    return {
        type: BRANCHING,
        payload: { controlId: e.target.id, value: e.target.value }
    };
}

function returnLoadAction(data) {
    return {
        type: LOAD,
        payload: data
    };
}