import { Component, Input } from '@angular/core';
import { ArticleModel } from '../models/article.model';

@Component({
    selector: 'app-article',
    imports: [],
    templateUrl: './article.html',
    styleUrl: './article.css',
})
export class Article {
    private symbols: number = 250;
    @Input() article!: ArticleModel;
    @Input() articleDesc!: string;
    descToShow: string;
    articleDescLen: number;
    showReadMoreBtn: boolean = true;
    showHideBtn: boolean = false;
    imageIsShown: boolean = false;
    imageButtonTitle: string = "Show Image";

    constructor() {
        this.articleDescLen = 0;
        this.descToShow = '';
    }

    readMore(): void {
        this.articleDescLen += this.symbols;

        if (this.articleDescLen >= this.articleDesc.length) {
            this.descToShow = this.articleDesc;
            this.showHideBtn = true;
            this.showReadMoreBtn = false;
        } else {
            this.descToShow = this.articleDesc.substring(0, this.articleDescLen);
        }
    }

}
