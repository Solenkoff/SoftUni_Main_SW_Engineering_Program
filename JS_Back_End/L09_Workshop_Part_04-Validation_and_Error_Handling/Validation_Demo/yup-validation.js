const yup = require('yup');

// Define the schema
const schema = yup.object({
  name: yup.string().required(),
  age: yup.number().min(18).required(),
  email: yup.string().email().required()
});

// Data to validate
const data = {
  name: 'John Doe',
  age: 25,
  email: 'john.doe@example.com'
};

// Validate the data
schema.validate(data)
  .then(() => {
    console.log('Data is valid!');
  })
  .catch((err) => {
    console.log('Data is invalid:', err.errors);
  });
