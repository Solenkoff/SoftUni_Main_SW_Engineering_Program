// -----  V_01    Git   MarioEmilov   -----

class Hex {                            
    constructor(value) {
        this.value = value;
    };
    valueOf() {
        return this.value;
    };
    toString() {
        return `0x${(this.value.toString(16)).toUpperCase()}`;
    };
    plus(number) {
        let newNumP = number.value + this.value;
        return new Hex(newNumP);
    };
    minus(number) {
        let newNumM = this.value - number.value;
        return new Hex(newNumM);
    };
    parse(string) {
        return parseInt(string, 16);
    };
}


// ----  V_02  Git SilviyaIvanova91    -----

// class Hex {
//     constructor(x) {
//       this.param = x;
//     }
  
//     valueOf() {
//       return this.param;
//     }
  
//     plus(obj) {
//       let result = this.param + Number(obj.valueOf());
//       return new Hex(result);
//     }
  
//     minus(obj) {
//       let result = this.param - Number(obj.valueOf());
//       return new Hex(result);
//     }
  
//     toString() {
//       return "0x" + this.param.toString(16).toUpperCase();
//     }
  
//     parse(str) {
//       return parseInt(str, 16);
//     }
//   }
  
  let FF = new Hex(255);
  console.log(FF.toString());
  FF.valueOf() + 1 == 256;
  let a = new Hex(10);
  let b = new Hex(5);
  console.log(a.plus(b).toString());
  console.log(a.plus(b).toString() === "0xF");
  console.log(FF.parse("AAA"));