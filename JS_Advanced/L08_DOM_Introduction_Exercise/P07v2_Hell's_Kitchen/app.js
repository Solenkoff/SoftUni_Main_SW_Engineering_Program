function solve() {
   document.querySelector('#btnSend').addEventListener('click', onClick);


   function onClick() {

       const inputData = JSON.parse(document.querySelector('#inputs textarea').value);

       const restaurants = {};

       inputData.forEach(e => {

           const [restaurantName, workersData] = e.split(' - ');
           const workersData = workersData.split(', ');

           let workers = [];

           for (const data of workersData) {
               const [name, salary] = data.split(' ');

               const worker = {
                   name,
                   salary
               }

               workers.push(worker);
           }

           if (restaurants[restaurantName]) {
               workers = workers.concat(restaurants[restaurantName].workers);
           };

           workers.sort((a, b) => b.salary - a.salary);

           const bestSalary = Number(workers[0].salary);

           const avgSalary = workers.reduce((sum, worker) => sum + Number(worker.salary), 0) / workers.length;

           restaurants[restaurantName] = {
               workers,
               avgSalary,
               bestSalary
           }
       });


       let bestRestaurantName = undefined;
       let bestSalary = 0;

       for (const restaurant in restaurants) {
           let currAvgSalary = restaurants[restaurant].avgSalary;

           if (restaurants[restaurant].avgSalary > bestSalary) {
               bestRestaurantName = restaurant;
               bestSalary = currAvgSalary;
           }
       }

       const bestRestaurant = restaurants[bestRestaurantName];

       const restaurantOutput = document.querySelector('#bestRestaurant>p');

       restaurantOutput.textContent =
           `Name: ${bestRestaurantName} Average Salary: ${bestRestaurant.avgSalary.toFixed(2)} Best Salary: ${bestRestaurant.bestSalary.toFixed(2)}`;

       const workersOutput = document.querySelector('#workers>p');

       let workersToString = [];

       bestRestaurant.workers.forEach(w => {
           workersToString.push(`Name: ${w.name} With Salary: ${w.salary}`)
       });


       workersOutput.textContent = workersToString.join(' ');

   }
}