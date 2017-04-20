const formState = { formData: new Map(), isFormValid : true };
const store = Redux.createStore(formReducer, formState);

var BRANCHING = "Branching";
var LOAD = "Load";
var VALIDATION = "Validation";
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
        case VALIDATION:
            newState = {
                formData: state.formData,
            }
            newState.isFormValid = action.payload;
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

function returnValidationAction(data){
    return {
        type: VALIDATION,
        payload: data
    };
};
