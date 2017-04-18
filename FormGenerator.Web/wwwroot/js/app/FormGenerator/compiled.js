"use strict";

var _createClass = function () { function defineProperties(target, props) { for (var i = 0; i < props.length; i++) { var descriptor = props[i]; descriptor.enumerable = descriptor.enumerable || false; descriptor.configurable = true; if ("value" in descriptor) descriptor.writable = true; Object.defineProperty(target, descriptor.key, descriptor); } } return function (Constructor, protoProps, staticProps) { if (protoProps) defineProperties(Constructor.prototype, protoProps); if (staticProps) defineProperties(Constructor, staticProps); return Constructor; }; }();

function _classCallCheck(instance, Constructor) { if (!(instance instanceof Constructor)) { throw new TypeError("Cannot call a class as a function"); } }

function _possibleConstructorReturn(self, call) { if (!self) { throw new ReferenceError("this hasn't been initialised - super() hasn't been called"); } return call && (typeof call === "object" || typeof call === "function") ? call : self; }

function _inherits(subClass, superClass) { if (typeof superClass !== "function" && superClass !== null) { throw new TypeError("Super expression must either be null or a function, not " + typeof superClass); } subClass.prototype = Object.create(superClass && superClass.prototype, { constructor: { value: subClass, enumerable: false, writable: true, configurable: true } }); if (superClass) Object.setPrototypeOf ? Object.setPrototypeOf(subClass, superClass) : subClass.__proto__ = superClass; }

var FormGeneratorComponent = function (_React$Component) {
    _inherits(FormGeneratorComponent, _React$Component);

    function FormGeneratorComponent(props) {
        _classCallCheck(this, FormGeneratorComponent);

        var _this = _possibleConstructorReturn(this, (FormGeneratorComponent.__proto__ || Object.getPrototypeOf(FormGeneratorComponent)).call(this, props));

        _this.branchingControls = _this.props.branching === undefined ? [] : JSON.parse(_this.props.branching);
        _this.hasBranchingControls = _this.branchingControls.length === 0;
        return _this;
    }

    _createClass(FormGeneratorComponent, [{
        key: "getInitialState",
        value: function getInitialState() {
            return {
                value: "",
                isVisible: this.hasBranchingControls,
                validationState: null,
                validationMessages: new Map()
            };
        }
    }, {
        key: "getIsVisible",
        value: function getIsVisible(formData) {
            if (this.hasBranchingControls) return true;
            var i = false;
            this.branchingControls.forEach(function (item) {
                if (formData[item.ParentCode] === item.BranchingValue) {
                    i = true;
                    return;
                }
            });
            return i;
        }
    }, {
        key: "getIsVisibleClassName",
        value: function getIsVisibleClassName() {
            return this.state.isVisible ? "show" : "hidden";
        }
    }, {
        key: "validate",
        value: function validate() {
            if (!this.state.isVisible) {
                this.setState({ validationState: null });
                return;
            }

            var messages = new Map();
            if (this.state.isVisible && this.state.value.length === 0) {
                this.setState({ validationState: "error" });
                messages.set(this.props.code, "is required");
            } else this.setState({ validationState: null });
            this.setState({ validationMessages: messages });
            //store.dispatch(returnValidationAction(messages));
        }
    }, {
        key: "handleChange",
        value: function handleChange(e) {
            this.setState({ value: e.target.value });
            this.validate();
            store.dispatch(returnBranchingAction(e));
        }
    }, {
        key: "setValidationMessages",
        value: function setValidationMessages(messages) {
            this.setState({ validationMessages: messags });
        }
    }, {
        key: "handleControlledComponentChange",
        value: function handleControlledComponentChange(e) {
            this.setState({ value: e.target.value });
        }
    }, {
        key: "handleBlur",
        value: function handleBlur(e) {
            this.setState({ value: e.target.value });
            this.validate();
            store.dispatch(returnBranchingAction(e));
        }
    }, {
        key: "componentDidMount",
        value: function componentDidMount() {
            var _this2 = this;

            store.subscribe(function () {
                var fd = store.getState().formData;
                _this2.setState({ isVisible: _this2.getIsVisible(fd) });
            });
        }
    }]);

    return FormGeneratorComponent;
}(React.Component);
"use strict";

var _createClass = function () { function defineProperties(target, props) { for (var i = 0; i < props.length; i++) { var descriptor = props[i]; descriptor.enumerable = descriptor.enumerable || false; descriptor.configurable = true; if ("value" in descriptor) descriptor.writable = true; Object.defineProperty(target, descriptor.key, descriptor); } } return function (Constructor, protoProps, staticProps) { if (protoProps) defineProperties(Constructor.prototype, protoProps); if (staticProps) defineProperties(Constructor, staticProps); return Constructor; }; }();

function _classCallCheck(instance, Constructor) { if (!(instance instanceof Constructor)) { throw new TypeError("Cannot call a class as a function"); } }

function _possibleConstructorReturn(self, call) { if (!self) { throw new ReferenceError("this hasn't been initialised - super() hasn't been called"); } return call && (typeof call === "object" || typeof call === "function") ? call : self; }

function _inherits(subClass, superClass) { if (typeof superClass !== "function" && superClass !== null) { throw new TypeError("Super expression must either be null or a function, not " + typeof superClass); } subClass.prototype = Object.create(superClass && superClass.prototype, { constructor: { value: subClass, enumerable: false, writable: true, configurable: true } }); if (superClass) Object.setPrototypeOf ? Object.setPrototypeOf(subClass, superClass) : subClass.__proto__ = superClass; }

var CheckboxList = function (_React$Component) {
    _inherits(CheckboxList, _React$Component);

    function CheckboxList() {
        _classCallCheck(this, CheckboxList);

        return _possibleConstructorReturn(this, (CheckboxList.__proto__ || Object.getPrototypeOf(CheckboxList)).apply(this, arguments));
    }

    _createClass(CheckboxList, [{
        key: "render",
        value: function render() {
            return React.createElement(
                ReactBootstrap.FormGroup,
                { controlId: this.props.code },
                React.createElement("input", { type: "check", id: this.props.id, name: this.props.id })
            );
        }
    }]);

    return CheckboxList;
}(React.Component);
"use strict";

var _createClass = function () { function defineProperties(target, props) { for (var i = 0; i < props.length; i++) { var descriptor = props[i]; descriptor.enumerable = descriptor.enumerable || false; descriptor.configurable = true; if ("value" in descriptor) descriptor.writable = true; Object.defineProperty(target, descriptor.key, descriptor); } } return function (Constructor, protoProps, staticProps) { if (protoProps) defineProperties(Constructor.prototype, protoProps); if (staticProps) defineProperties(Constructor, staticProps); return Constructor; }; }();

function _classCallCheck(instance, Constructor) { if (!(instance instanceof Constructor)) { throw new TypeError("Cannot call a class as a function"); } }

function _possibleConstructorReturn(self, call) { if (!self) { throw new ReferenceError("this hasn't been initialised - super() hasn't been called"); } return call && (typeof call === "object" || typeof call === "function") ? call : self; }

function _inherits(subClass, superClass) { if (typeof superClass !== "function" && superClass !== null) { throw new TypeError("Super expression must either be null or a function, not " + typeof superClass); } subClass.prototype = Object.create(superClass && superClass.prototype, { constructor: { value: subClass, enumerable: false, writable: true, configurable: true } }); if (superClass) Object.setPrototypeOf ? Object.setPrototypeOf(subClass, superClass) : subClass.__proto__ = superClass; }

var DatePicker = function (_FormGeneratorCompone) {
    _inherits(DatePicker, _FormGeneratorCompone);

    function DatePicker(props) {
        _classCallCheck(this, DatePicker);

        var _this = _possibleConstructorReturn(this, (DatePicker.__proto__ || Object.getPrototypeOf(DatePicker)).call(this, props));

        _this.state = _this.getInitialState();
        return _this;
    }

    _createClass(DatePicker, [{
        key: "render",
        value: function render() {
            return React.createElement(
                ReactBootstrap.FormGroup,
                { controlId: this.props.code, className: this.getIsVisibleClassName(), validationState: this.state.validationState },
                React.createElement(
                    ReactBootstrap.Col,
                    { sm: this.props.cols },
                    React.createElement(
                        ReactBootstrap.ControlLabel,
                        null,
                        this.props.label
                    ),
                    React.createElement(ReactBootstrap.FormControl, { type: "text", name: this.props.code, onChange: this.handleControlledComponentChange.bind(this), onBlur: this.handleBlur.bind(this), value: this.state.value }),
                    React.createElement(ValidationMessage, { messages: this.state.validationMessages })
                )
            );
        }
    }]);

    return DatePicker;
}(FormGeneratorComponent);
"use strict";

var _createClass = function () { function defineProperties(target, props) { for (var i = 0; i < props.length; i++) { var descriptor = props[i]; descriptor.enumerable = descriptor.enumerable || false; descriptor.configurable = true; if ("value" in descriptor) descriptor.writable = true; Object.defineProperty(target, descriptor.key, descriptor); } } return function (Constructor, protoProps, staticProps) { if (protoProps) defineProperties(Constructor.prototype, protoProps); if (staticProps) defineProperties(Constructor, staticProps); return Constructor; }; }();

function _classCallCheck(instance, Constructor) { if (!(instance instanceof Constructor)) { throw new TypeError("Cannot call a class as a function"); } }

function _possibleConstructorReturn(self, call) { if (!self) { throw new ReferenceError("this hasn't been initialised - super() hasn't been called"); } return call && (typeof call === "object" || typeof call === "function") ? call : self; }

function _inherits(subClass, superClass) { if (typeof superClass !== "function" && superClass !== null) { throw new TypeError("Super expression must either be null or a function, not " + typeof superClass); } subClass.prototype = Object.create(superClass && superClass.prototype, { constructor: { value: subClass, enumerable: false, writable: true, configurable: true } }); if (superClass) Object.setPrototypeOf ? Object.setPrototypeOf(subClass, superClass) : subClass.__proto__ = superClass; }

var Dropdown = function (_React$Component) {
    _inherits(Dropdown, _React$Component);

    function Dropdown(props) {
        _classCallCheck(this, Dropdown);

        return _possibleConstructorReturn(this, (Dropdown.__proto__ || Object.getPrototypeOf(Dropdown)).call(this, props));
    }

    _createClass(Dropdown, [{
        key: "render",
        value: function render() {
            var json = JSON.parse(this.props.children);
            var optionItems = json.map(function (item) {
                return React.createElement(
                    "option",
                    { value: item.Id },
                    item.Description
                );
            }, this);
            return React.createElement(
                ReactBootstrap.FormGroup,
                { controlId: this.props.id },
                React.createElement(
                    ReactBootstrap.Col,
                    { sm: this.props.cols },
                    React.createElement(
                        ReactBootstrap.ControlLabel,
                        null,
                        this.props.label
                    ),
                    React.createElement(
                        ReactBootstrap.FormControl,
                        { componentClass: "select", placeholder: "select" },
                        optionItems
                    )
                )
            );
        }
    }]);

    return Dropdown;
}(React.Component);
"use strict";

var _createClass = function () { function defineProperties(target, props) { for (var i = 0; i < props.length; i++) { var descriptor = props[i]; descriptor.enumerable = descriptor.enumerable || false; descriptor.configurable = true; if ("value" in descriptor) descriptor.writable = true; Object.defineProperty(target, descriptor.key, descriptor); } } return function (Constructor, protoProps, staticProps) { if (protoProps) defineProperties(Constructor.prototype, protoProps); if (staticProps) defineProperties(Constructor, staticProps); return Constructor; }; }();

function _classCallCheck(instance, Constructor) { if (!(instance instanceof Constructor)) { throw new TypeError("Cannot call a class as a function"); } }

function _possibleConstructorReturn(self, call) { if (!self) { throw new ReferenceError("this hasn't been initialised - super() hasn't been called"); } return call && (typeof call === "object" || typeof call === "function") ? call : self; }

function _inherits(subClass, superClass) { if (typeof superClass !== "function" && superClass !== null) { throw new TypeError("Super expression must either be null or a function, not " + typeof superClass); } subClass.prototype = Object.create(superClass && superClass.prototype, { constructor: { value: subClass, enumerable: false, writable: true, configurable: true } }); if (superClass) Object.setPrototypeOf ? Object.setPrototypeOf(subClass, superClass) : subClass.__proto__ = superClass; }

var Label = function (_React$Component) {
    _inherits(Label, _React$Component);

    function Label(props) {
        _classCallCheck(this, Label);

        return _possibleConstructorReturn(this, (Label.__proto__ || Object.getPrototypeOf(Label)).call(this, props));
    }

    _createClass(Label, [{
        key: "render",
        value: function render() {
            return React.createElement(
                "label",
                { htmlFor: this.props.for },
                this.props.description
            );
        }
    }]);

    return Label;
}(React.Component);
"use strict";

var _createClass = function () { function defineProperties(target, props) { for (var i = 0; i < props.length; i++) { var descriptor = props[i]; descriptor.enumerable = descriptor.enumerable || false; descriptor.configurable = true; if ("value" in descriptor) descriptor.writable = true; Object.defineProperty(target, descriptor.key, descriptor); } } return function (Constructor, protoProps, staticProps) { if (protoProps) defineProperties(Constructor.prototype, protoProps); if (staticProps) defineProperties(Constructor, staticProps); return Constructor; }; }();

function _classCallCheck(instance, Constructor) { if (!(instance instanceof Constructor)) { throw new TypeError("Cannot call a class as a function"); } }

function _possibleConstructorReturn(self, call) { if (!self) { throw new ReferenceError("this hasn't been initialised - super() hasn't been called"); } return call && (typeof call === "object" || typeof call === "function") ? call : self; }

function _inherits(subClass, superClass) { if (typeof superClass !== "function" && superClass !== null) { throw new TypeError("Super expression must either be null or a function, not " + typeof superClass); } subClass.prototype = Object.create(superClass && superClass.prototype, { constructor: { value: subClass, enumerable: false, writable: true, configurable: true } }); if (superClass) Object.setPrototypeOf ? Object.setPrototypeOf(subClass, superClass) : subClass.__proto__ = superClass; }

var RadioButtonList = function (_FormGeneratorCompone) {
    _inherits(RadioButtonList, _FormGeneratorCompone);

    function RadioButtonList(props) {
        _classCallCheck(this, RadioButtonList);

        var _this = _possibleConstructorReturn(this, (RadioButtonList.__proto__ || Object.getPrototypeOf(RadioButtonList)).call(this, props));

        _this.state = _this.getInitialState();
        return _this;
    }

    _createClass(RadioButtonList, [{
        key: "render",
        value: function render() {
            var json = JSON.parse(this.props.children);
            var radioButtons = json.map(function (item, index) {
                return React.createElement(
                    ReactBootstrap.Radio,
                    { key: index, name: this.props.code, id: this.props.code + "_" + item.Id, value: item.Id, onClick: this.handleRadioButtonClick.bind(this), inline: true },
                    item.Description
                );
            }, this);
            return React.createElement(
                ReactBootstrap.FormGroup,
                { className: this.getIsVisibleClassName(this.state) },
                React.createElement(
                    ReactBootstrap.Col,
                    { sm: this.props.cols },
                    React.createElement(
                        ReactBootstrap.ControlLabel,
                        { htmlFor: this.props.code },
                        this.props.label
                    ),
                    radioButtons
                )
            );
        }
    }, {
        key: "handleRadioButtonClick",
        value: function handleRadioButtonClick(e) {
            store.dispatch({ type: BRANCHING, payload: { controlId: e.target.name, value: e.target.value } });
        }
    }]);

    return RadioButtonList;
}(FormGeneratorComponent);
"use strict";

var _createClass = function () { function defineProperties(target, props) { for (var i = 0; i < props.length; i++) { var descriptor = props[i]; descriptor.enumerable = descriptor.enumerable || false; descriptor.configurable = true; if ("value" in descriptor) descriptor.writable = true; Object.defineProperty(target, descriptor.key, descriptor); } } return function (Constructor, protoProps, staticProps) { if (protoProps) defineProperties(Constructor.prototype, protoProps); if (staticProps) defineProperties(Constructor, staticProps); return Constructor; }; }();

function _classCallCheck(instance, Constructor) { if (!(instance instanceof Constructor)) { throw new TypeError("Cannot call a class as a function"); } }

function _possibleConstructorReturn(self, call) { if (!self) { throw new ReferenceError("this hasn't been initialised - super() hasn't been called"); } return call && (typeof call === "object" || typeof call === "function") ? call : self; }

function _inherits(subClass, superClass) { if (typeof superClass !== "function" && superClass !== null) { throw new TypeError("Super expression must either be null or a function, not " + typeof superClass); } subClass.prototype = Object.create(superClass && superClass.prototype, { constructor: { value: subClass, enumerable: false, writable: true, configurable: true } }); if (superClass) Object.setPrototypeOf ? Object.setPrototypeOf(subClass, superClass) : subClass.__proto__ = superClass; }

var SaveButton = function (_React$Component) {
    _inherits(SaveButton, _React$Component);

    function SaveButton(props) {
        _classCallCheck(this, SaveButton);

        return _possibleConstructorReturn(this, (SaveButton.__proto__ || Object.getPrototypeOf(SaveButton)).call(this, props));
    }

    _createClass(SaveButton, [{
        key: "render",
        value: function render() {
            return React.createElement(
                ReactBootstrap.FormGroup,
                null,
                React.createElement(
                    ReactBootstrap.Col,
                    { sm: this.props.cols },
                    React.createElement(
                        ReactBootstrap.Button,
                        { id: this.props.id, name: this.props.id, type: "submit", bsStyle: "primary" },
                        "Save"
                    )
                )
            );
        }
    }]);

    return SaveButton;
}(React.Component);
"use strict";

var _createClass = function () { function defineProperties(target, props) { for (var i = 0; i < props.length; i++) { var descriptor = props[i]; descriptor.enumerable = descriptor.enumerable || false; descriptor.configurable = true; if ("value" in descriptor) descriptor.writable = true; Object.defineProperty(target, descriptor.key, descriptor); } } return function (Constructor, protoProps, staticProps) { if (protoProps) defineProperties(Constructor.prototype, protoProps); if (staticProps) defineProperties(Constructor, staticProps); return Constructor; }; }();

function _classCallCheck(instance, Constructor) { if (!(instance instanceof Constructor)) { throw new TypeError("Cannot call a class as a function"); } }

function _possibleConstructorReturn(self, call) { if (!self) { throw new ReferenceError("this hasn't been initialised - super() hasn't been called"); } return call && (typeof call === "object" || typeof call === "function") ? call : self; }

function _inherits(subClass, superClass) { if (typeof superClass !== "function" && superClass !== null) { throw new TypeError("Super expression must either be null or a function, not " + typeof superClass); } subClass.prototype = Object.create(superClass && superClass.prototype, { constructor: { value: subClass, enumerable: false, writable: true, configurable: true } }); if (superClass) Object.setPrototypeOf ? Object.setPrototypeOf(subClass, superClass) : subClass.__proto__ = superClass; }

var Textbox = function (_FormGeneratorCompone) {
    _inherits(Textbox, _FormGeneratorCompone);

    function Textbox(props) {
        _classCallCheck(this, Textbox);

        var _this = _possibleConstructorReturn(this, (Textbox.__proto__ || Object.getPrototypeOf(Textbox)).call(this, props));

        _this.state = _this.getInitialState();
        return _this;
    }

    _createClass(Textbox, [{
        key: "render",
        value: function render() {
            return React.createElement(
                ReactBootstrap.FormGroup,
                { controlId: this.props.code, bsSize: "small", className: this.getIsVisibleClassName(), validationState: this.state.validationState },
                React.createElement(
                    ReactBootstrap.Col,
                    { sm: this.props.cols },
                    React.createElement(
                        ReactBootstrap.ControlLabel,
                        null,
                        this.props.label
                    ),
                    React.createElement(ReactBootstrap.FormControl, { type: "text", name: this.props.code, value: this.state.value, onChange: this.handleControlledComponentChange.bind(this), onBlur: this.handleBlur.bind(this) }),
                    React.createElement(ValidationMessage, { messages: this.state.validationMessages })
                )
            );
        }
    }]);

    return Textbox;
}(FormGeneratorComponent);
"use strict";

var _createClass = function () { function defineProperties(target, props) { for (var i = 0; i < props.length; i++) { var descriptor = props[i]; descriptor.enumerable = descriptor.enumerable || false; descriptor.configurable = true; if ("value" in descriptor) descriptor.writable = true; Object.defineProperty(target, descriptor.key, descriptor); } } return function (Constructor, protoProps, staticProps) { if (protoProps) defineProperties(Constructor.prototype, protoProps); if (staticProps) defineProperties(Constructor, staticProps); return Constructor; }; }();

function _classCallCheck(instance, Constructor) { if (!(instance instanceof Constructor)) { throw new TypeError("Cannot call a class as a function"); } }

function _possibleConstructorReturn(self, call) { if (!self) { throw new ReferenceError("this hasn't been initialised - super() hasn't been called"); } return call && (typeof call === "object" || typeof call === "function") ? call : self; }

function _inherits(subClass, superClass) { if (typeof superClass !== "function" && superClass !== null) { throw new TypeError("Super expression must either be null or a function, not " + typeof superClass); } subClass.prototype = Object.create(superClass && superClass.prototype, { constructor: { value: subClass, enumerable: false, writable: true, configurable: true } }); if (superClass) Object.setPrototypeOf ? Object.setPrototypeOf(subClass, superClass) : subClass.__proto__ = superClass; }

var ValidationMessage = function (_React$Component) {
    _inherits(ValidationMessage, _React$Component);

    function ValidationMessage(props) {
        _classCallCheck(this, ValidationMessage);

        return _possibleConstructorReturn(this, (ValidationMessage.__proto__ || Object.getPrototypeOf(ValidationMessage)).call(this, props));
    }

    _createClass(ValidationMessage, [{
        key: "render",
        value: function render() {
            if (this.props.messages.size > 0) {
                var vm = this.props.messages;
                var m = vm.forEach(function (value, key, map) {
                    return React.createElement(
                        "li",
                        null,
                        "is required"
                    );
                }, this);
                console.log(m);
                return React.createElement(
                    "ul",
                    null,
                    React.createElement(
                        "li",
                        null,
                        m
                    )
                );
            } else return null;
        }
    }]);

    return ValidationMessage;
}(React.Component);
