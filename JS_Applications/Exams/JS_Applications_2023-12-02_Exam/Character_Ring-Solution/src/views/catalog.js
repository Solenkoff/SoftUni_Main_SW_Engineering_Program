import { getAllCharacters } from '../data/characters.js';
import { html, render } from '../lib.js';

const catalogTemplate = (characters) => html`
    <h2>Characters</h2>
    <section id="characters">
      <!-- Display a div with information about every post (if any)-->
        ${characters.length ? characters.map(characterTemplate) : html`
        <h2>No added Heroes yet.</h2>`}
         <!-- Display an h2 if there are no posts -->
    </section>
`;

//     category, imageUrl, description, moreInfo

const characterTemplate = (character) =>html`
    <div class="character">
        <img src=${character.imageUrl} alt="example1" />
        <div class="hero-info">
            <h3 class="category">${character.category}</h3>
            <p class="description">${character.description}</p>
            <a class="details-btn" href="/details/${character._id}">More Info</a>
        </div>
    </div>
`;


export async function showCatalog(ctx){
    const characters = await getAllCharacters();
    
    render(catalogTemplate(characters));
}


//    Object { 
//    ​​
//       _createdOn: 1617194295480
//       ​​
//       _id: "136777f5-3277-42ad-b874-76d043b069cb"
//       ​​
//       _ownerId: "847ec027-f659-4086-8032-5173e2f9c93a"
//       ​​
//       category: "Bandit"
//       ​​
//       description: "The Bandit ..."
//       ​​
//       imageUrl: "/images/hero 3.png"
//       ​​
//       moreInfo: "However, all its ..."
//    }