window.onload = solution();

function solution() {

    const mainEl = document.getElementById('main');
    getArticles();

    async function getArticles() {
        try {
            const articlesUrl = 'http://localhost:3030/jsonstore/advanced/articles/list';
            const resonse = await fetch(articlesUrl);
            const data = await resonse.json();

            renderArticles(data);

        } catch (error) {
            errorHandler(error);
        }
    }

    function renderArticles(articlesData) {
        for (const article of articlesData) {
            const articleContainer = createEl('div', 'accordion');
            const headWrapper = createEl('div', 'head', undefined, undefined, articleContainer);
            const titleEl = createEl('span', undefined, article.title, undefined, headWrapper);
            const buttonEl = createEl('button', 'button', 'More', { id: `${article._id}` }, headWrapper);

            buttonEl.addEventListener('click', moreLessTogle);

            mainEl.appendChild(articleContainer);
        }
    }

    async function moreLessTogle(e) {
        const button = e.target;

        const articleId = button.id;
        const url = `http://localhost:3030/jsonstore/advanced/articles/details/${articleId}`;
        try {
            const response = await fetch(url);
            const data = await response.json()

            renderTogle(button, data);
        } catch (error) {
            errorHandler(error);
        }
    }

    function renderTogle(button, data) {
        const articleEl = button.parentElement.parentElement;
        const extraEl = createEl('div', 'extra');
        const textEl = createEl('p', undefined, data.content, undefined, extraEl);

        if (button.textContent == 'More') {
            button.textContent = 'Less';
            articleEl.appendChild(extraEl);
            extraEl.style.display = 'block';

        } else {
            button.textContent = 'More';
            articleEl.children[1].remove();
        }
    }


    function errorHandler(error) {
        alert(error);
    }

    function createEl(type, className, content, attributes, appender) {
        const el = document.createElement(type);
        if (className) {
            el.className = className;
        }
        if (content) {
            el.textContent = content;
        }
        if (attributes) {
            Object.entries(attributes).forEach(([key, value]) => {
                el.setAttribute(key, value == true ? '' : value);
            })
        }
        if (appender) {
            appender.appendChild(el);
        }

        return el;
    }

}
