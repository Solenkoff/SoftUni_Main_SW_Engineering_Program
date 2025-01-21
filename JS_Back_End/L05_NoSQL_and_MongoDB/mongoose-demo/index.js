import mongoose, { Schema, model } from 'mongoose';

const uri = 'mongodb://127.0.0.1:27017/studentsDb';      //  127.0.0.1 = localhost

try {
    await mongoose.connect(uri);
    console.log('Successfully connected to DB!');
} catch (err) {
    console.log('Cannot connect to DB!');
}


//  Set up mongoose schema
const studentSchema = new Schema({
    name: String,
    age: {
        type: Number,
        required: [true, 'Required field!'],
        min: [18, `Student age should be at least 18 years old!`],
        max: [120, `Student age should be max 120 years old!`],
    },
});


//  Create custom instance method
studentSchema.method('getInfo', function () {     //  !!!  No Arrow function (to keep the context -> this.name)    
    return `I am ${this.name} and I'm ${this.age} years old!`;
})
// studentSchema.methods.getInfo = function () {         //  !!!  No Arrow function (to keep the context -> this.name)
//     return `I am ${this.name} and I'm ${this.age} years old!`;
// }


//  Create custom validation
studentSchema.path('age').validate(function (age) {
    return age >= 18 && age <= 120;
})


//  Create mongoose model
const Student = model('Student', studentSchema);

const students = await Student.find();
//console.log(students);

//  Query data from model with filter
//const filteredStudents = await Student.find({age: 20});
//   ==   const filteredStudents = await Student.find({age: {$eq: 20}});
//console.log(filteredStudents);


//  Insert data into db #1
//  const newStudent = new Student({age: 24, name: 'Ivo'});
//  await newStudent.save();

//  Insert data into db #2
// const createdStudent = await Student.create({
//     name: 'Niki',
//     age: 19,
// }); 
// console.log(createdStudent);

//  Get singleStudent 
const singleStudent = await Student.findOne({ age: 20 });
console.log(singleStudent);

//  Using model custom method
console.log(singleStudent.getInfo());

//  Failed custom validation
try {
    await Student.create({
        name: 'Test2',
        age: 12,
    });
} catch (err) {
    console.log(err.message);
}


//  -----    CRUD    -----

//  Update
//    #1  singleStudent.name = 'Neshto drugo';
//        singleStudent.save();

//    #2
await Student.updateOne({ name: 'Ivo', age: 24 }, { name: 'Ivaylo', age: 29 });

// //  Delete
// //    #1     Best
// await Student.findByIdAndDelete('67966251f9bab2aedd516c83');
// //    #2
// await Student.deleteOne({'_id': '67966251f9bab2aedd516c83'});
// //    #3   
// await Student.deleteMany({age: 24}); 


//  -----    Queries    -----

//  MongoDB query with $or operator
// const resultStudent = await Student.find({
//     $or: [
//         { name: 'Ivo' },
//         { age: { $lt: 22 } }
//     ]
// });
// console.log(resultStudent);

//  MongoDB query with $or operator
const resultStudent2 = await Student.find()
    .or( [
        { name: 'Ivo' },
        { age: { $lt: 22 } }
    ])
    //.select({name: 1, _id: 0});

console.log(resultStudent2);
