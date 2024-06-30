// ----  V_01  Git Universe8888    -----

(function() {
    Array.prototype.last = function() {
      return this[this.length - 1];
    };
  
    Array.prototype.skip = function(n) {
      return this.slice(n);
    };
  
    Array.prototype.take = function(n) {
      return this.slice(0, n);
    };
  
    Array.prototype.sum = function() {
      return this.reduce((acc, curr) => acc + curr, 0);
    };
  
    Array.prototype.average = function() {
      if (this.length === 0) {
        return 0;
      }
      return this.sum() / this.length;
    };
  })();
  
// ----  V_02  Git Universe8888    -----
  
//   (function() {
//     Array.prototype.last = function() {
//       return this[this.length - 1];
//     };
  
//     Array.prototype.skip = function(n) {
//       let result = [];
//       for (let i = n; i < this.length; i++) {
//         result.push(this[i]);
//       }
//       return result;
//     };
  
//     Array.prototype.take = function(n) {
//       let result = [];
//       for (let i = 0; i < n; i++) {
//         result.push(this[i]);
//       }
//       return result;
//     };
  
//     Array.prototype.sum = function() {
//       return this.reduce((acc, curr) => acc + curr, 0);
//     };
  
//     Array.prototype.average = function() {
//       return this.sum() / this.length;
//     };
//   })();