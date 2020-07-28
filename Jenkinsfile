pipeline {
	agent {
		label 'Windows_Node'
	}
	stages {
		stage('Git-Checkout') {
			steps {
				echo "Checking out from Git Repo";
				git 'https://github.com/USI-DevOps/SeleniumNUnitParam'
			}
		}
		
		stage('Restore Nuget') {
			steps {
				echo "Restoring Nuget packages";		
				bat 'C:/DevOps/Tools/nuget.exe restore SeleniumNUnitParam.sln'
			}
		}

		
		stage('Build') {
			steps {
				echo "Building the checked-out project";
				bat 'C:\DevOps\BuildTools\MSBuild\MSBuild.exe SeleniumNUnitParam.sln /p:Configuration=Debug /p:Platform=\"Any CPU\" /p:ProductVersion=1.0.0.${env.BUILD_NUMBER}'
				//bat "\"${tool 'MSBuild'}\"  SeleniumNUnitParam.sln /p:Configuration=Debug /p:Platform=\"Any CPU\" /p:ProductVersion=1.0.0.${env.BUILD_NUMBER}"
			}
		}
		
		stage('NUnit-Test') {
			steps {
				echo "Running NUnit Tests";			
				bat 'C:/DevOps/Tools/NUnit.Console-3.11.1/bin/net35/nunit3-console.exe SeleniumNUnitParam/bin/Debug/SeleniumNUnitParam.dll' 
			}
		}
		
		stage('Quality-Gate') {
			steps {
				echo "Verfying Quality Gates";
			}
		}
		
		stage('Deploy') {
			steps {
				echo "Deploying to stage environment for more tests!";
			}
		}
	}
	post {
		always {
			echo "This will always run"
		}
		success {
			echo "This will run only if successful, trigger a mail"
		}
		failure {
			echo "This will run only if failed"
		}
		unstable {
			echo "This will run only if the run was marked as unstable"
		}
		changed {
			echo "This will run only if the state of the pipeline has cahnged"
			echo "Ex: if the pipeline was previously failing but is now success"
		}
	}
}
