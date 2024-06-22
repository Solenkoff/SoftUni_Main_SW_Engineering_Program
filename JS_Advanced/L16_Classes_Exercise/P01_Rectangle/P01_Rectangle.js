//  V-01  Simple solution

// class Rectangle {
//     width;
//     height;
//     color;

//     constructor(w, h, c){
//         this.width = w;
//         this.height = h;
//         this.color = c;
//     }

//     calcArea(){
//         return this.width * this.height;
//     }

// }

class Rectangle {
    _width;
    _height;
    _color;

    constructor(w, h, c) {
        this.width = w;
        this.height = h;
        this.color = c;
    }

    get width() {
        return this._width;
    }

    set width(value) {
        if (value <= 0) {
            throw new Error('Width must be a positive number.');
        }
        this._width = value;
    }

    get height() {
        return this._height;
    }

    set height(value) {
        if (value <= 0) {
            throw new Error('Height must be a positive number.');
        }
        this._height = value;
    }

    get color() {
        return this._color;
    }

    set color(value) {
        if (typeof(value) != 'string') {
            throw new Error('Color must be a string.');
        }
        this._color = value.charAt(0).toUpperCase() + value.slice(1).toLowerCase();
    }

    calcArea() {
        return this._width * this._height;
    }
}

let rect = new Rectangle(4, 5, 'Red');
console.log(rect.width);
console.log(rect.height);
console.log(rect.color);
console.log(rect.calcArea());
