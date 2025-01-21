import { MongoClient } from 'mongodb';

const uri = 'mongodb://127.0.0.1:27017';     // URI = Connection string  !!!  ( localhost:27017 => 127.0.0.1:27017 )
const client = new MongoClient(uri);

try {
    await client.connect();

    console.log('Connected successfully');
} catch (err) {
    console.error('Could not connect to db');
}

const db = client.db('studentsDb'); 
const collection = db.collection('students');

const result = await collection.find().toArray();
console.log(result);  