"use strict";

var _createClass = (function () { function defineProperties(target, props) { for (var i = 0; i < props.length; i++) { var descriptor = props[i]; descriptor.enumerable = descriptor.enumerable || false; descriptor.configurable = true; if ("value" in descriptor) descriptor.writable = true; Object.defineProperty(target, descriptor.key, descriptor); } } return function (Constructor, protoProps, staticProps) { if (protoProps) defineProperties(Constructor.prototype, protoProps); if (staticProps) defineProperties(Constructor, staticProps); return Constructor; }; })();

var _get = function get(_x, _x2, _x3) { var _again = true; _function: while (_again) { var object = _x, property = _x2, receiver = _x3; _again = false; if (object === null) object = Function.prototype; var desc = Object.getOwnPropertyDescriptor(object, property); if (desc === undefined) { var parent = Object.getPrototypeOf(object); if (parent === null) { return undefined; } else { _x = parent; _x2 = property; _x3 = receiver; _again = true; desc = parent = undefined; continue _function; } } else if ("value" in desc) { return desc.value; } else { var getter = desc.get; if (getter === undefined) { return undefined; } return getter.call(receiver); } } };

function _interopRequireDefault(obj) { return obj && obj.__esModule ? obj : { "default": obj }; }

function _classCallCheck(instance, Constructor) { if (!(instance instanceof Constructor)) { throw new TypeError("Cannot call a class as a function"); } }

function _inherits(subClass, superClass) { if (typeof superClass !== "function" && superClass !== null) { throw new TypeError("Super expression must either be null or a function, not " + typeof superClass); } subClass.prototype = Object.create(superClass && superClass.prototype, { constructor: { value: subClass, enumerable: false, writable: true, configurable: true } }); if (superClass) Object.setPrototypeOf ? Object.setPrototypeOf(subClass, superClass) : subClass.__proto__ = superClass; }

var _antd = require('../antd');

var _antd2 = _interopRequireDefault(_antd);

var Parent = (function (_React$Component) {
    _inherits(Parent, _React$Component);

    function Parent(props) {
        _classCallCheck(this, Parent);

        _get(Object.getPrototypeOf(Parent.prototype), "constructor", this).call(this, props);
        this.state = { sidebarOpen: true };
        this.handleViewSidebar = this.handleViewSidebar.bind(this);
    }

    _createClass(Parent, [{
        key: "handleViewSidebar",
        value: function handleViewSidebar() {
            this.setState({ sidebarOpen: !this.state.sidebarOpen });
        }
    }, {
        key: "render",
        value: function render() {
            return React.createElement(
                "div",
                { className: "parent" },
                React.createElement(Header, { onClick: this.handleViewSidebar }),
                React.createElement(SideBar, { isOpen: this.state.sidebarOpen, toggleSidebar: this.handleViewSidebar }),
                React.createElement(Content, { isOpen: this.state.sidebarOpen })
            );
        }
    }]);

    return Parent;
})(React.Component);

var Header = (function (_React$Component2) {
    _inherits(Header, _React$Component2);

    function Header() {
        _classCallCheck(this, Header);

        _get(Object.getPrototypeOf(Header.prototype), "constructor", this).apply(this, arguments);
    }

    _createClass(Header, [{
        key: "render",
        value: function render() {
            return React.createElement(
                "header",
                null,
                React.createElement(
                    "a",
                    { href: "javascript:;", onClick: this.props.onClick },
                    "Click Me!"
                )
            );
        }
    }]);

    return Header;
})(React.Component);

var SideBar = (function (_React$Component3) {
    _inherits(SideBar, _React$Component3);

    function SideBar() {
        _classCallCheck(this, SideBar);

        _get(Object.getPrototypeOf(SideBar.prototype), "constructor", this).apply(this, arguments);
    }

    _createClass(SideBar, [{
        key: "render",
        value: function render() {
            var sidebarClass = 'sidebar' + (this.props.isOpen && ' open' || '');
            return React.createElement(
                "div",
                { className: sidebarClass },
                React.createElement(
                    "div",
                    null,
                    "I slide into view"
                ),
                React.createElement(
                    "div",
                    null,
                    "Me too!"
                ),
                React.createElement(
                    "div",
                    null,
                    "Meee Threeeee!"
                ),
                React.createElement(
                    "button",
                    { onClick: this.props.toggleSidebar, className: "sidebar-toggle" },
                    "Toggle Sidebar"
                )
            );
        }
    }]);

    return SideBar;
})(React.Component);

var Content = (function (_React$Component4) {
    _inherits(Content, _React$Component4);

    function Content() {
        _classCallCheck(this, Content);

        _get(Object.getPrototypeOf(Content.prototype), "constructor", this).apply(this, arguments);
    }

    _createClass(Content, [{
        key: "render",
        value: function render() {
            var contentClass = 'content' + (this.props.isOpen && ' open' || '');
            return React.createElement(
                "div",
                { className: contentClass },
                React.createElement(
                    "div",
                    null,
                    "I am content fill me up!I am content fill me up!I am content fill me up!I am content fill me up!I am content fill me up!I am content fill me up!I am content fill me up!I am content fill me up!I am content fill me up!I am content fill me up!I am content fill me up!I am content fill me up!I am content fill me up!I am content fill me up!I am content fill me up!I am content fill me up!I am content fill me up!I am content fill me up!I am content fill me up!I am content fill me up!I am content fill me up!I am content fill me up!I am content fill me up!I am content fill me up!I am content fill me up!I am content fill me up!I am content fill me up!I am content fill me up!I am content fill me up!I am content fill me up!"
                ),
                React.createElement(_antd2["default"], null)
            );
        }
    }]);

    return Content;
})(React.Component);

ReactDOM.render(React.createElement(Parent, null), document.getElementById('body'));

