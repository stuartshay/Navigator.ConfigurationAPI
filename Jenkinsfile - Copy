node('docker') {

    stage('Git checkout') {
        git branch: 'master', credentialsId: 'gihub-key', url: 'git@github.com:stuartshay/Navigator.ConfigurationAPI.git'
    }

   stage('Build & Deploy Docker') {
        sh '''mv docker/navigator-configuration-api-build.dockerfile/.dockerignore .dockerignore
        docker build -f docker/navigator-configuration-api-build.dockerfile/Dockerfile --build-arg BUILD_NUMBER=${BUILD_NUMBER} -t stuartshay/navigator-configuration-api:3.1.1-build .'''
        withCredentials([usernamePassword(credentialsId: 'docker-hub-navigatordatastore', usernameVariable: 'DOCKER_HUB_LOGIN', passwordVariable: 'DOCKER_HUB_PASSWORD')]) {
            sh "docker login -u ${DOCKER_HUB_LOGIN} -p ${DOCKER_HUB_PASSWORD}"
        }
        sh '''docker push stuartshay/navigator-configuration-api:3.1.1-build'''
    }


    stage('Mail') {
        emailext attachLog: true, body: '', subject: "Jenkins build status - ${currentBuild.fullDisplayName}", to: 'sshay@yahoo.com'
    }

}
