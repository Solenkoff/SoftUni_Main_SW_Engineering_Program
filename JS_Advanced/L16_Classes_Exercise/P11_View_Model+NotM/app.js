// ----  V_01  Git Universe8888    -----

class Textbox {
    constructor(selector, regex) {
        this._elements = document.querySelectorAll(selector);
        this._invalidSymbols = regex;
        this._value = this._elements[0].value;
        this.onInput();
    }

    get value() {
        return this._value;
    }

    set value(value) {
        this._value = value;
        for (let el of this._elements) {
            el.value = value;
        }
    }

    get elements() {
        return this._elements;
    }

    isValid() {
        return !this._invalidSymbols.test(this.value);
    }

    onInput() {
        for (let el of this._elements) {
            el.addEventListener('input', (event) => {
                this.value = el.value;
            });
        }
    }
}


let textbox = new Textbox(".textbox",/[^a-zA-Z0-9]/);
let inputs = document.getElementsByClassName('.textbox');

inputs.addEventListener('click',function(){console.log(textbox.value);});
