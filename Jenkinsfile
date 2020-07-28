pipeline {
	environment {
		//This variable need be tested as string
		doError = '0'
    	}
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
				bat label: '', script: 'C:\\DevOps\\BuildTools\\MSBuild\\MSBuild.exe SeleniumNUnitParam.sln /p:Configuration=Debug /p:ProductVersion=1.0.0.${env.BUILD_NUMBER}'
				//bat 'C:\DevOps\BuildTools\MSBuild\MSBuild.exe SeleniumNUnitParam.sln /p:Configuration=Debug /p:Platform=\"Any CPU\" /p:ProductVersion=1.0.0.${env.BUILD_NUMBER}'
				//bat "\"${tool 'MSBuild'}\"  SeleniumNUnitParam.sln /p:Configuration=Debug /p:Platform=\"Any CPU\" /p:ProductVersion=1.0.0.${env.BUILD_NUMBER}"
			}
		}
		
		stage('NUnit-Test') {
			steps {
				echo "Running NUnit Tests";			
				bat 'C:/DevOps/Tools/NUnit.Console-3.11.1/bin/net35/nunit3-console.exe SeleniumNUnitParam/bin/Debug/SeleniumNUnitParam.dll' 
				
				archiveArtifacts artifacts: "TestResult.xml"
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
		
		stage('Email') {
			steps {
				echo "Sending email after build";
				emailext body: 'Build completed @ %Date%.%Time%', subject: 'Build Completed', to: 'developerprofiles@gmail.com'
			}
		}	
		
		stage('Download') {
		    steps {
			echo "Archieve test step";
			sh 'mkdir js'
			sh 'echo "not a artifact file" > js/build.js'
			sh 'echo "artifact file" > js/build.min.js'

			sh 'mkdir css'
			sh 'echo "not a artifact file" > css/build.css'
			sh 'echo "artifact file" > css/build.min.css'
		    }
		}
		
		stage('Error') {
		    when {
			expression { doError == '1' }
		    }
		    steps {
			echo "Failure"
			error "failure test. It's work"
		    }
		}

		stage('Success') {
		    when {
			expression { doError == '0' }
		    }
		    steps {
			echo "ok"
		    }
		}	
		
	}
	post {
		always {
			echo "This will always run"			
			//archiveArtifacts artifacts: '**/*.min.*', onlyIfSuccessful: true
			
			//emailext body: '<p>EXECUTED: Job <b>\'${env.JOB_NAME}:${env.BUILD_NUMBER})\'</b></p><p>View console output at <a href=\'${env.BUILD_URL}\'>${env.JOB_NAME}:${env.BUILD_NUMBER}</a> has result ${currentBuild.result}"</p><p><i>(Build log is attached.)</i></p>', compressLog: true, replyTo: 'developerprofiles@gmail.com', subject: 'Status: ${currentBuild.result?:\'SUCCESS\'} - Job \'${env.JOB_NAME}:${env.BUILD_NUMBER}\'', to: 'developerprofiles@gmail.com'		}
			emailext body: '<p>EXECUTED: Job <b>\'${env.JOB_NAME}:${env.BUILD_NUMBER})\'</b></p><p>View console output at <a href=\'${env.BUILD_URL}\'>${env.JOB_NAME}:${env.BUILD_NUMBER}</a> has result {currentBuild.result}"</p><p><i>(Build log is attached.)</i></p>', compressLog: true, replyTo: 'developerprofiles@gmail.com', subject: 'Status: {currentBuild.result?:\'SUCCESS\'} - Job \'${env.JOB_NAME}:${env.BUILD_NUMBER}\'', to: 'developerprofiles@gmail.com'		}
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
