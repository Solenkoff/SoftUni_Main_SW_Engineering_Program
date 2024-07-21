function attachEvents() {

    const postsEl = document.getElementById('posts');

    const loadPostsBtn = document.getElementById('btnLoadPosts');
    loadPostsBtn.addEventListener('click', loadPosts);

    const viewPostBtn = document.getElementById('btnViewPost');
    viewPostBtn.addEventListener('click', viewPost)

    const baseUrl = 'http://localhost:3030/jsonstore/blog/';

    async function loadPosts() {
        const allPostsUrl = `${baseUrl}posts`;

        try {
            const resonse = await fetch(allPostsUrl);
            const data = await resonse.json();

            postsEl.replaceChildren();
            Object.values(data).forEach(postData => renderPost(postData));

        } catch (error) {
            alert(error);
        }

    }

    async function viewPost(){
        const postId = document.getElementById('posts').value;

        const postData = await getPostData(postId);
        const allComments = await getAllComments();

        const currPostComments = Object.values(allComments).filter(c => c.postId == postId);

        const postTitleEl = document.getElementById('post-title');
        postTitleEl.textContent = postData.title.toUpperCase();
        const postBodyEl = document.getElementById('post-body'); 
        postBodyEl.textContent = postData.body;

        const postCommentsEl = document.getElementById('post-comments');
        postCommentsEl.replaceChildren();

        currPostComments.forEach(comment => {
            const commentEl = createEl('li', comment.text, {'id': comment.id});
            postCommentsEl.appendChild(commentEl);
        })

    }

    async function getAllComments(){
        const url = `${baseUrl}comments`;

        try {
            const resonse = await fetch(url);
            const data = await resonse.json();

            return data;
        } catch (error) {
            alert(error);
        }
    }

    async function getPostData(postId){
        const url = `${baseUrl}posts/${postId}`;

        try {
            const resonse = await fetch(url);
            const data = await resonse.json();

            return data;
        } catch (error) {
            alert(error);
        }
    }

    function renderPost(postData) {
        const optionEl = createEl('option', postData.title.toUpperCase(), {'value': postData.id});     //  .toUpperCase()
        postsEl.appendChild(optionEl);
    }

    function createEl (type, content, attributes){
        const el = document.createElement(type);

        if(content){
            el.textContent = content;
        }
        if(attributes){
            Object.entries(attributes).forEach(([key, value]) => {
                el.setAttribute(key, value);
            })
        }

        return el;
    }

}

attachEvents();