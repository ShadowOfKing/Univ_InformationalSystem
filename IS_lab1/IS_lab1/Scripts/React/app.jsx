
class Parent extends React.Component {
    constructor(props) {
        super(props);
        this.state = { sidebarOpen: true };
        this.handleViewSidebar = this.handleViewSidebar.bind(this);
    }
    handleViewSidebar() {
        this.setState({ sidebarOpen: !this.state.sidebarOpen });
    }
    render() {
        return (
            <div className="parent">
                <Header onClick={this.handleViewSidebar} />
                <SideBar isOpen={this.state.sidebarOpen} toggleSidebar={this.handleViewSidebar} />
                <Content isOpen={this.state.sidebarOpen} />
            </div>
        );
    }
}

class Header extends React.Component {
    render() {
        return (
            <header>
                <a href="javascript:;" onClick={this.props.onClick}>Click Me!</a>
            </header>
        );
    }
}

class SideBar extends React.Component {
    render() {
        var sidebarClass = 'sidebar' + (this.props.isOpen && ' open' || '');
        return (
            <div className={sidebarClass}>
                <div>I slide into view</div>
                <div>Me too!</div>
                <div>Meee Threeeee!</div>
                <button onClick={this.props.toggleSidebar} className="sidebar-toggle">Toggle Sidebar</button>
            </div>
        );
    }
}

class Content extends React.Component {
    render() {
        var contentClass = 'content' + (this.props.isOpen && ' open' || '');
        return (
            <div className={contentClass}>
                <div>I am content fill me up!I am content fill me up!I am content fill me up!I am content fill me up!I am content fill me up!I am content fill me up!I am content fill me up!I am content fill me up!I am content fill me up!I am content fill me up!I am content fill me up!I am content fill me up!I am content fill me up!I am content fill me up!I am content fill me up!I am content fill me up!I am content fill me up!I am content fill me up!I am content fill me up!I am content fill me up!I am content fill me up!I am content fill me up!I am content fill me up!I am content fill me up!I am content fill me up!I am content fill me up!I am content fill me up!I am content fill me up!I am content fill me up!I am content fill me up!</div>
            </div>
        );
    }
}

ReactDOM.render(
    <Parent />,
    document.getElementById('body')
);