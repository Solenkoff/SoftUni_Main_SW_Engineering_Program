window.addEventListener("load", solve);

function solve() {

  const publishButton = document.getElementById('publish-btn');
  publishButton.addEventListener('click', onPublish);

  const postTitleInputEl = document.getElementById('post-title');
  const postCategoryInputEl = document.getElementById('post-category');
  const postContentInputEl = document.getElementById('post-content');
  const reviewEl = document.getElementById('review-list');
  const publishedEl = document.getElementById('published-list');
  const clearBtn = document.getElementById('clear-btn');
  clearBtn.addEventListener('click', onClear);

 
  function onPublish(e) {
    const title = postTitleInputEl.value;
    const category = postCategoryInputEl.value;
    const content = postContentInputEl.value;

    if (!title || !category || !content) {
      return;
    }

    postTitleInputEl.value = '';
    postCategoryInputEl.value = '';
    postContentInputEl.value = '';

    const postLiElement = createElement('li', undefined, 'rpost');
    const articleElement = createElement('article', undefined, undefined, postLiElement);
    const titleH4Element = createElement('h4', title, undefined, articleElement);
    const categoryPElement = createElement('p', category, undefined, articleElement);
    const contentPElement = createElement('p', content, undefined, articleElement);
    const editButton = createElement('button', 'Edit', 'action-btn edit', postLiElement);
    editButton.addEventListener('click', onEdit)
    const approveButton = createElement('button', 'Approve', 'action-btn approve', postLiElement);
    approveButton.addEventListener('click', onApprove);

    reviewEl.appendChild(postLiElement);

    
  }


  function onEdit(e) {
    e.preventDefault();

    const title = e.currentTarget.parentNode.querySelector('h4').textContent;
    const category = e.currentTarget.parentNode.querySelector('p:nth-of-type(1)').textContent;
    const content = e.currentTarget.parentNode.querySelector('p:nth-of-type(2)').textContent;

    postTitleInputEl.value = title;
    postCategoryInputEl.value = category;
    postContentInputEl.value = content;

    e.currentTarget.parentNode.remove();
  }


  function onApprove(e){
    const articleLiElement = e.currentTarget.parentNode;
    Array.from(articleLiElement.querySelectorAll('button')).forEach(el => el.remove());

    publishedEl.appendChild(articleLiElement);
  }


  function onClear(){
    //publishedEl.innerHTML = '';
    Array.from(publishedEl.children).forEach(el => el.remove());
  }

  function createElement(type, text, className, parent) {
    const newElement = document.createElement(type);
    if (text) {
      newElement.textContent = text;
    }
    if (className) {
      newElement.className = className;
    }
    if (parent) {
      parent.appendChild(newElement);
    }

    return newElement;
  }

}
