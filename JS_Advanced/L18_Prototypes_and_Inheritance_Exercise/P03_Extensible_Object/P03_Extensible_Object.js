// ----  V_01  Git Universe8888    -----

function extensibleObject() {
    let obj = {
        extend: function (template) {
            for (let prop in template) {
                if (typeof template[prop] === 'function') {
                    Object.getPrototypeOf(obj)[prop] = template[prop];
                } else {
                    obj[prop] = template[prop];
                }
            }
        }
    };
    return obj;
}

// ----  V_02  Git SilviyaIvanova91    -----

function solve() {
    let proto = {};
    let inst = Object.create(proto);
  
    inst.extend = function (templates) {
      Object.entries(templates).forEach(([k, v]) => {
        if (typeof v === "function") {
          proto[k] = v;
        } else {
          inst[k] = v;
        }
      });
    };
    return inst;
  }