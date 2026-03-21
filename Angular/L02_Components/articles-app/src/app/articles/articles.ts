import { Component, OnInit } from '@angular/core';
import { Article } from '../article/article';
import { ArticleData } from '../data/data';
import { ArticleModel } from '../models/article.model';

@Component({
    selector: 'app-articles',
    imports: [Article],
    templateUrl: './articles.html',
    styleUrl: './articles.css',
})

export class Articles implements OnInit {
    articles!: ArticleModel[];
    constructor() { }

    ngOnInit() {
        this.articles = new ArticleData().getData();
    }
}
