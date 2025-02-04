const Ajv = require('ajv');

const ajv = new Ajv();

// Define the schema
const schema = {
  type: 'object',
  properties: {
    name: { type: 'string' },
    age: { type: 'integer', minimum: 18 },
    email: { type: 'string', format: 'email' }
  },
  required: ['name', 'age', 'email'],
  additionalProperties: false
};

// Create a validator function from the schema
const validate = ajv.compile(schema);

// Data to validate
const data = {
  name: 'John Doe',
  age: 25,
  email: 'john.doe@example.com'
};

// Validate the data
const valid = validate(data);

if (valid) {
  console.log('Data is valid!');
} else {
  console.log('Data is invalid:', validate.errors);
}
