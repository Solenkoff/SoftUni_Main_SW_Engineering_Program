pipeline{
    agent any
    stages{
        stage("Build the project"){
            steps{
                bat 'dotnet build'                //   As per requirement no separate restore stage
            }
        }
        stage("Run Unit and Integration Tests"){
            steps{
                bat 'dotnet test --no-build --verbosity normal'
            }
        }
    }
}