import { getAllFunFacts } from '../data/funFacts.js';
import { html, render } from '../lib.js';

const catalogTemplate = (funFacts) => html`
    <h2>Fun Facts</h2>
    <section id="dashboard">
          <!-- Display a div with information about every post (if any)-->
        ${funFacts.length ? funFacts.map(funFactTemplate) : html`
            <h2>No Fun Facts yet.</h2>`}
         <!-- Display an h2 if there are no posts -->
    </section>
`;

//     category, imageUrl, description, moreInfo

const funFactTemplate = (funFact) =>html`
    <div class="fact">
        <img src=${funFact.imageUrl} alt="example1" />
        <h3 class="category">${funFact.category}</h3>
        <p class="description">${funFact.description}</p>
        <a class="details-btn" href="/details/${funFact._id}">More Info</a>
    </div>
`;


export async function showCatalog(ctx){
    const funFacts = await getAllFunFacts();
    
    render(catalogTemplate(funFacts));
}


//    Object { 
//    ​​
//       _createdOn: 1617194295480
//       ​​
//       _id: "136777f5-3277-42ad-b874-76d043b069cb"
//       ​​
//       _ownerId: "847ec027-f659-4086-8032-5173e2f9c93a"
//       ​​
//       category: "Nature"
//       ​​
//       description: "Prepare to be astounded by..."
//       ​​
//       imageUrl: "/images/fact 3.jpg"
//       ​​
//       moreInfo: "Hummingbirds are truly remarkable creatures. ..."
//    }