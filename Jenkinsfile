pipeline{
    agent any
    stages{
        stage("Restore project dependencies"){
            steps{
                bat 'dotnet restore'
            }
        }
        stage("Build the project"){
            steps{
                bat 'dotnet build --no-restore'
            }
        }
        stage("Run Unit and Integration Tests"){
            steps{
                bat 'dotnet test --no-build --verbosity normal'
            }
        }
    }
}