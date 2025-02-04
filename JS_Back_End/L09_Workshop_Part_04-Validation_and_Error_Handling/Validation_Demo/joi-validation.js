const Joi = require('joi');

// Define the schema
const schema = Joi.object({
  name: Joi.string().required(),
  age: Joi.number().min(18).required(),
  email: Joi.string().email().required()
});

// Data to validate
const data = {
  name: 'John Doe',
  age: 25,
  email: 'john.doe@example.com'
};

// Validate the data
const { error } = schema.validate(data);

if (!error) {
  console.log('Data is valid!');
} else {
  console.log('Data is invalid:', error.details);
}