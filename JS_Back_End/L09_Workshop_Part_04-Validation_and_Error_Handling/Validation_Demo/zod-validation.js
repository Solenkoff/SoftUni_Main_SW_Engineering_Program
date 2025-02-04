const { z } = require('zod');

// Define the schema
const schema = z.object({
  name: z.string(),
  age: z.number().min(18),
  email: z.string().email()
});

// Data to validate
const data = {
  name: 'John Doe',
  age: 25,
  email: 'john.doe@example.com'
};

// Validate the data
try {
  schema.parse(data);
  console.log('Data is valid!');
} catch (error) {
  console.log('Data is invalid:', error.errors);
}
