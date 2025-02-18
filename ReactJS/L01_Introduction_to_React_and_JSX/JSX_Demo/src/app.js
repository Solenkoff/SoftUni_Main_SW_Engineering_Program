
// Get DOM contaiiner
const rootDomElement = document.getElementById('root');

// Create root 
const reactRootElement = ReactDOM.createRoot(rootDomElement);

// Create React element  without JSX
const headingReactElement = React.createElement('h1', {}, 'Hello from React!');
const subHeadingReactElement = React.createElement('h2', { id: 'sub-header'}, 'The best framework!');
const headerSectionReactElement = React.createElement('header', {}, headingReactElement, subHeadingReactElement); 



// Create React element  with JSX
const headerSectionReactJSXElement = (
    <header>
        <h1>Hello from JSX</h1>
        <h2 id="sub-header">The best superset language!</h2>
        <p>Lorem ipsum dolor, sit amet consectetur adipisicing elit. Distinctio, accusamus!</p>
    </header>
);

// Render element to UI
reactRootElement.render(headerSectionReactJSXElement);  

// Compare react element vs dom element
setTimeout(() => {
    const subHeadingDomElement = document.getElementById('sub-header');
    console.dir(subHeadingDomElement);
    console.dir(subHeadingReactElement);

}, 500);