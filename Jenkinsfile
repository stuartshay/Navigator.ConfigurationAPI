node('buildx') {
    
    String version_prefix = '3.1.1'
    String version_suffix = ''
    String docker_image_name = 'stuartshay/navigator-configuration-api'
    String docker_file = 'docker/navigator-configuration-api-build.dockerfile/Dockerfile'
    String docker_ignore = 'docker/navigator-configuration-api-build.dockerfile/.dockerignore'
    String git_path = '' 
    String platform = 'linux/amd64'
    String email = 'sshay@yahoo.com' // TODO FIX

    stage('Git checkout') {
        def gitRepo = checkout scm
        String git_url = gitRepo.GIT_URL
        git_branch = gitRepo.GIT_BRANCH.tokenize('/')[-1]

             String git_commit_id = gitRepo.GIT_COMMIT
             String git_short_commit_id = "${git_commit_id[0..6]}"

             String buildTime = sh(returnStdout: true, script: "date +'%Y.%V'").trim()
             currentBuild.displayName = (buildTime + "." + currentBuild.number + "." + git_branch + "." + git_short_commit_id)
    }

    stage('Build & Deploy Docker') {
        
        sh """mv ${docker_ignore} .dockerignore
        docker context ls
        """
          
        if (git_branch == 'master')
        {
            sh """
            docker buildx build --platform=${platform} -f ${docker_file} --build-arg BUILD_NUMBER=${BUILD_NUMBER} -t ${docker_image_name}:${version_prefix}.${BUILD_NUMBER} .
            """
            withCredentials([usernamePassword(credentialsId: 'docker-hub-navigatordatastore', usernameVariable: 'DOCKER_HUB_LOGIN', passwordVariable: 'DOCKER_HUB_PASSWORD')]) {
            sh "docker login -u ${DOCKER_HUB_LOGIN} -p ${DOCKER_HUB_PASSWORD}"
            }
            sh """
            docker push ${docker_image_name}:${version_prefix}.${BUILD_NUMBER}
            """
        }
        else
        {
            sh """
            docker buildx build --platform=${platform} -f ${docker_file} --build-arg BUILD_NUMBER=${BUILD_NUMBER} -t ${docker_image_name}:${version_prefix}-${BUILD_NUMBER}-prerelease-${git_branch} ${git_path}/.
            """
            withCredentials([usernamePassword(credentialsId: 'docker-hub-navigatordatastore', usernameVariable: 'DOCKER_HUB_LOGIN', passwordVariable: 'DOCKER_HUB_PASSWORD')]) {
            sh "docker login -u ${DOCKER_HUB_LOGIN} -p ${DOCKER_HUB_PASSWORD}"
            }
            sh """
            docker push ${docker_image_name}:${version_prefix}-${BUILD_NUMBER}-prerelease-${git_branch}
            """
        }
    }

    stage('Mail') {
        emailext attachLog: true, body: '', subject: "Jenkins build status - ${currentBuild.fullDisplayName}", to: 'sshay@yahoo.com'
    }

 }   
