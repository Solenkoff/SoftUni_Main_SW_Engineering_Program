
// Get DOM contaiiner
var rootDomElement = document.getElementById('root');

// Create root 
var reactRootElement = ReactDOM.createRoot(rootDomElement);

// Create React element  without JSX
var headingReactElement = React.createElement('h1', {}, 'Hello from React!');
var subHeadingReactElement = React.createElement('h2', { id: 'sub-header' }, 'The best framework!');
var headerSectionReactElement = React.createElement('header', {}, headingReactElement, subHeadingReactElement);

// Create React element  without JSX
var headerSectionReactJSXElement = React.createElement(
    'header',
    null,
    React.createElement(
        'h1',
        null,
        'Hello from JSX'
    ),
    React.createElement(
        'h2',
        { id: 'sub-header' },
        'The best superset language!'
    ),
    React.createElement(
        'p',
        null,
        'Lorem ipsum dolor, sit amet consectetur adipisicing elit. Distinctio, accusamus!'
    )
);

// Render element to UI
reactRootElement.render(headerSectionReactJSXElement);

// Compare react element vs dom element
setTimeout(function () {
    var subHeadingDomElement = document.getElementById('sub-header');
    console.dir(subHeadingDomElement);
    console.dir(subHeadingReactElement);
}, 500);