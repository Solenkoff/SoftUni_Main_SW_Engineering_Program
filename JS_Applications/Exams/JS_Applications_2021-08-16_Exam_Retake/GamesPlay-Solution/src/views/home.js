import { html, render } from '../lib.js';
import { getLatestGames } from '../data/games.js';

const homeTemplate = ( games ) => html`
    <section id="welcome-world">
        <div class="welcome-message">
            <h2>ALL new games are</h2>
            <h3>Only in GamesPlay</h3>
        </div>
        <img src="./images/four_slider_img01.png" alt="hero">

        <div id="home-page">
            <h1>Latest Games</h1>
            <!-- Display div: with information about every game (if any) -->
            ${games.length ? games.map(gameTemplate) : html`
            <p class="no-articles">No games yet</p>`}
            <!-- Display paragraph: If there is no games  -->
        </div>
    </section>
`;

const gameTemplate = (game) =>html`
    <div class="game">
        <div class="image-wrap">
            <img src=${game.imageUrl}>
        </div>
        <h3>${game.title}</h3>
        <div class="rating">
            <span>☆</span><span>☆</span><span>☆</span><span>☆</span><span>☆</span>
        </div>
        <div class="data-buttons">
            <a href="/details/${game._id}" class="btn details-btn">Details</a>
        </div>
    </div>
`;

//    title, category, maxLevel, imageUrl, summary

export async function showHome(ctx) {
    const games = await getLatestGames();

    render(homeTemplate(games.slice(0, 3)));
}