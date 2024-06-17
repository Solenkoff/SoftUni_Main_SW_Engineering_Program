function solve() {

    //   Gather input values
    const input = {
        name: document.getElementById("task"),
        description: document.getElementById("description"),
        date: document.getElementById("date"),
    };
    const [_, openSection, progressSection, finishedSection] = Array.from(document.querySelectorAll("section"))
                                                                    .map((e) => e.children[1]);
    document.getElementById("add").addEventListener("click", addTask);

    function addTask(event) {
        event.preventDefault();

        //  Create DOM elements
        const article = document.createElement("article");
        
        article.appendChild(createElementFunc("h3", input.name.value));
        article.appendChild(createElementFunc("p", `Description: ${input.description.value}`));
        article.appendChild(createElementFunc("p", `Due Date: ${input.date.value}`));

        const div = createElementFunc("div", "", "flex");

        const startButton = createElementFunc("button", "Start", "green");
        const daleteButton = createElementFunc("button", "Delete", "red");
        const finishButton = createElementFunc("button", "Finish", "orange");

        div.appendChild(startButton);
        div.appendChild(daleteButton);

        article.appendChild(div);

        //  Append article to section
        openSection.appendChild(article);

        //  Clear Input Fields
        Object.values(input).forEach((i) => (i.value = ""));

        // Buttons  ==>  Start, Delete, Finish 
        startButton.addEventListener("click", onStart);
        daleteButton.addEventListener("click", onDelete);
        finishButton.addEventListener("click", onFinish);

        function onStart() {
            startButton.remove();
            div.appendChild(finishButton);
            progressSection.appendChild(article);
        }

        function onDelete() {
            article.remove();
        }

        function onFinish() {
            div.remove();
            finishedSection.appendChild(article);
        }
    }

    function createElementFunc(type, content, className) {
        const element = document.createElement(type);
        element.textContent = content;
        if (className) {
            element.className = className;
        }
        return element;
    }
}