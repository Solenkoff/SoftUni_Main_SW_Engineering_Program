var Box = /** @class */ (function () {
    function Box() {
        this.elements = [];
    }
    Box.prototype.add = function (el) {
        this.elements.push(el);
    };
    Box.prototype.remove = function () {
        this.elements.pop();
    };
    Object.defineProperty(Box.prototype, "count", {
        get: function () {
            return this.elements.length;
        },
        enumerable: false,
        configurable: true
    });
    return Box;
}());
var box = new Box();
box.add(1);
box.add(2);
box.add(3);
console.log(box.count);
// let box = new Box<String>();
// box.add("Pesho");
// box.add("Gosho");
// console.log(box.count);
// box.remove();
// console.log(box.count);
