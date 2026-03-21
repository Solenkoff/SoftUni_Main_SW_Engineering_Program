import { ArticleModel } from '../models/article.model';
import { data } from './seed';

export class ArticleData {
    getData(): ArticleModel[] {
        let articles: ArticleModel[] = [];

        for (let i = 0; i < data.length; i++) {
            articles[i] = new ArticleModel(
                data[i].title,
                data[i].description,
                data[i].author,
                data[i].imageUrl
            );
        }

        return articles;
    }
}