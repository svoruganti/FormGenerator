const formState = { formData: new Map(), validationMessages: new Map() };
const store = Redux.createStore(formReducer, formState);

var BRANCHING = "Branching";
var VALIDATION = "Validation";

function formReducer(state = formState, action) {
    switch (action.type) {
        case BRANCHING:
            var newState = {
                formData: state.formData
            };
            newState.formData[action.payload.controlId] = action.payload.value;
            return newState;
        case VALIDATION:
            var newState = {
                formData: state.formData,
                validationMessages: new Map()
            };
            Object.keys(action.payload.validationMessages).forEach(function(item) {
                newState.validationMessages[item] = action.payload.validationMessages[item];
            });
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

function returnValidationAction(messages) {
    return {
        type: VALIDATION,
        payload: { validationMessages: messages }
    };
}