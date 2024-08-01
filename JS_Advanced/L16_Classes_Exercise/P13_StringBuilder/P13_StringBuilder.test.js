import {expect} from 'chai';
import {StringBuilder} from './P13_StringBuilder.js';

// ----  V_01  Git SilviyaIvanova91    -----

describe("StringBuilder", () => {
  describe("constructor", () => {
    it("Should initialize with empty array if undefined is passed", () => {
      let sb = new StringBuilder(undefined);
      expect(sb.toString()).to.equal("");
    });

    it("Should throw Error if passed a non-string argument", () => {
      expect(() => new StringBuilder(1.23)).to.throw(TypeError);
      expect(() => new StringBuilder(null)).to.throw(TypeError);
    });

    it("Should initialize correct array when passed a valid string", () => {
      let sb1 = new StringBuilder("abc");
      let sb2 = new StringBuilder("test");
      expect(sb1.toString()).to.equal("abc");
      expect(sb2.toString()).to.equal("test");
    });
  });

  describe("append", () => {
    it("Should throw when passed a non-string argument", () => {
      let sb = new StringBuilder();
      expect(() => sb.append(true)).to.throw(
        TypeError,
        "Argument must be a string"
      );
      let sb2 = new StringBuilder("abc");
      expect(() => sb2.append(123)).to.throw(TypeError);
    });

    it("Should append only the string chars when passed a string argument", () => {
      let input = "123";
      let input2 = "wow";
      let expected = "abc123";
      let expected2 = "abc123wow";
      let expected3 = "abc123ww";

      let sb = new StringBuilder("abc");
      sb.append(input);
      expect(sb.toString()).to.equal(expected);
      sb.append(input2);
      expect(sb.toString()).to.equal(expected2);
      sb.remove(7, 1);
      expect(sb.toString()).to.equal(expected3);
    });
  });

  describe("prepend", () => {
    it("Should throw when passed a non-string argument", () => {
      let sb = new StringBuilder();
      expect(() => sb.prepend(true)).to.throw(
        TypeError,
        "Argument must be a string"
      );
      let sb2 = new StringBuilder("abc");
      expect(() => sb2.prepend(123)).to.throw(TypeError);
    });

    it("Should prepend string correctly when passed a string argument", () => {
      let input = "123";
      let input2 = "wow";
      let expected = "123abc";
      let expected2 = "wow123abc";
      let sb = new StringBuilder("abc");
      sb.prepend(input);
      expect(sb.toString()).to.equal(expected);
      sb.prepend(input2);
      expect(sb.toString()).to.equal(expected2);
    });

    it("Should prepend chars at correct index correctly when passed a string argument", () => {
      let input = "123";
      let input2 = "wow";
      let expected = "123abc";
      let expected2 = "wow123abc";
      let expected3 = "wow123bc";
      let sb = new StringBuilder("abc");
      sb.prepend(input);
      expect(sb.toString()).to.equal(expected);
      sb.prepend(input2);
      expect(sb.toString()).to.equal(expected2);
      sb.remove(6, 1);
      expect(sb.toString()).to.equal(expected3);
    });
  });

  describe("insertAt", () => {
    it("Should throw when passed a non-string argument", () => {
      let sb = new StringBuilder();
      expect(() => sb.insertAt(true, 0)).to.throw(
        TypeError,
        "Argument must be a string"
      );
      let sb2 = new StringBuilder("abc");
      expect(() => sb2.insertAt(123, 1)).to.throw(TypeError);
    });

    it("Should insert charts at correc index when passed a valid string", () => {
      let input = " fast";
      let input2 = " are";
      let expected = "cars fast";
      let expected2 = "cars are fast";
      let sb = new StringBuilder("cars");
      sb.insertAt(input, 4);
      expect(sb.toString()).to.equal(expected);
      sb.insertAt(input2, 4);
      expect(sb.toString()).to.equal(expected2);
    });

    it("Should insert charts at correc index when passed a valid string", () => {
      let input = " fast";
      let input2 = " are";
      let expected = "cars fast";
      let expected2 = "cars are fast";
      let expected3 = "cars are fat";

      let sb = new StringBuilder("cars");
      sb.insertAt(input, 4);
      expect(sb.toString()).to.equal(expected);
      sb.insertAt(input2, 4);
      expect(sb.toString()).to.equal(expected2);
      sb.remove(11, 1);
      expect(sb.toString()).to.equal(expected3);
    });
  });

  describe("remove", () => {
    it("Should remove chars at correct index", () => {
      let expected = "cars are fat";
      let expected2 = "cars fat";

      let sb = new StringBuilder("cars are fast");
      sb.remove(11, 1);
      expect(sb.toString()).to.equal(expected);
      sb.remove(4, 4);
      expect(sb.toString()).to.equal(expected2);
    });
  });

  describe("toString", () => {
    it("Should return correct string representation internal array when called", () => {
      let expected = "";
      let expected2 = "cars are fast";
      let sb = new StringBuilder();
      let sb2 = new StringBuilder(expected2);

      expect(sb.toString()).to.equal(expected);
      expect(sb2.toString()).to.equal(expected2);
    });
  });
});



// ----  V_02  Git  MarioEmilov   -----

describe('Tests for StringBuilder Class', () => {
    
  describe('Tests for the Constructor', () => {
      
      it('Should not throw an error if the input is a 1-letter string', () => {
          let instance = new StringBuilder('a');
          expect(() => instance).not.to.throw(TypeError, 'Argument must be a string');
          expect(instance.toString()).to.equal('a');
      });

      it('Should not throw an error if the input is a 3-letter string', () => {
          let instance = new StringBuilder('abc');
          expect(() => instance).not.to.throw(TypeError, 'Argument must be a string');
          expect(instance.toString()).to.equal('abc');
      });

      it('Should not throw an error if the input is undefined', () => {
          let instance = new StringBuilder();
          expect(() => instance).not.to.throw(TypeError, 'Argument must be a string');
          expect(instance.toString()).to.equal('');
      });

      it('Should throw an error if the input is not a string', () => {
          expect(() => new StringBuilder(123)).to.throw(TypeError, 'Argument must be a string');
          expect(() => new StringBuilder(['abc'])).to.throw(TypeError, 'Argument must be a string');
          expect(() => new StringBuilder(null)).to.throw(TypeError, 'Argument must be a string');
      });
  });

  describe('Tests for the append Method', () => {

      it('Should work as intended when the given input is a string', () => {
          let instance = new StringBuilder('abc');
          instance.append('123');
          expect(instance.toString()).to.equal('abc123');
      });

      it('Should throw an error when the given input is not a string', () => {
          let instance1 = new StringBuilder('abc');
          expect(() => instance1.append(undefined)).to.throw(TypeError, 'Argument must be a string');
          let instance2 = new StringBuilder('abc');
          expect(() => instance2.append(123)).to.throw(TypeError, 'Argument must be a string');
          let instance3 = new StringBuilder('abc');
          expect(() => instance3.append()).to.throw(TypeError, 'Argument must be a string');
      });
  });

  describe('Tests for the prepend Method', () => {

      it('Should work as intended when the given input is a string', () => {
          let instance = new StringBuilder('abc');
          instance.prepend('123');
          expect(instance.toString()).to.equal('123abc');
      });

      it('Should throw an error when the given input is not a string', () => {
          let instance1 = new StringBuilder('abc');
          expect(() => instance1.prepend(undefined)).to.throw(TypeError, 'Argument must be a string');
          let instance2 = new StringBuilder('abc');
          expect(() => instance2.prepend(123)).to.throw(TypeError, 'Argument must be a string');
          let instance3 = new StringBuilder('abc');
          expect(() => instance3.prepend()).to.throw(TypeError, 'Argument must be a string');
      });
  });

  describe('Tests for the insertAt Method', () => {

      it('Should work as intended when the first input is a string', () => {
          let instance1 = new StringBuilder('abc');
          instance1.insertAt('123', 1);
          expect(instance1.toString()).to.equal('a123bc');
          let instance2 = new StringBuilder('abc');
          instance2.insertAt('123', 4);
          expect(instance2.toString()).to.equal('abc123');
          let instance3 = new StringBuilder('abc');
          instance3.insertAt('123');
          expect(instance3.toString()).to.equal('123abc');
          let instance4 = new StringBuilder('abc');
          instance4.insertAt('123', -1);
          expect(instance4.toString()).to.equal('ab123c');
          let instance5 = new StringBuilder('abc');
          instance5.insertAt('123', -4);
          expect(instance5.toString()).to.equal('123abc');
      });

      it('Should throw an error when the given input is not a string', () => {
          let instance1 = new StringBuilder('abc');
          expect(() => instance1.insertAt(undefined)).to.throw(TypeError, 'Argument must be a string');
          let instance2 = new StringBuilder('abc');
          expect(() => instance2.insertAt(123, 1)).to.throw(TypeError, 'Argument must be a string');
          let instance3 = new StringBuilder('abc');
          expect(() => instance3.insertAt(123)).to.throw(TypeError, 'Argument must be a string');
          let instance4 = new StringBuilder('abc');
          expect(() => instance4.insertAt()).to.throw(TypeError, 'Argument must be a string');
      });
  });

  describe('Tests for the remove Method', () => {
      
      it('Should work as intended when the input is as wanted', () => {
          let instance1 = new StringBuilder('abc');
          instance1.remove(1, 0);
          expect(instance1.toString()).to.equal('abc');
          let instance2 = new StringBuilder('abc');
          instance2.remove(0, 1);
          expect(instance2.toString()).to.equal('bc');
          let instance3 = new StringBuilder('abc');
          instance3.remove(4, 1);
          expect(instance3.toString()).to.equal('abc');
          let instance4 = new StringBuilder('abc');
          instance4.remove(1, 4);
          expect(instance4.toString()).to.equal('a');
          let instance5 = new StringBuilder('abc');
          instance5.remove();
          expect(instance5.toString()).to.equal('abc');
      });
  });
  it('toString works correctly - 2', () => {
      const expected = '\n A \n\r B\t123   ';
      const obj = new StringBuilder();
  
      expected.split('').forEach(s => {obj.append(s); obj.prepend(s); });
  
      obj.insertAt('test', 4);
  
      obj.remove(2, 4);
  
      expect(obj.toString()).to.equal('  st21\tB \r\n A \n\n A \n\r B\t123   ');
  });
});